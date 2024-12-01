using Godot;
using LePlayer;
using System;

namespace DialogueSystem
{
    /// <summary>
    /// Stop the dialogue if the player gets to far 
    /// </summary>
    public partial class StopDialogue : Node
    {
        private Player _player;

        private Node3D _dialogueNodePos;

        public float CalculateDistance()
        {
            if (_player == null || _dialogueNodePos == null) return -1;
            var dist = _dialogueNodePos.GlobalPosition.DistanceTo(_player.Position);
            GD.Print(dist);
            return dist;
        }
        public void GetNodes()
        {
            _player ??= (Player)GetTree().GetFirstNodeInGroup("Player");
            _dialogueNodePos = DialogueManager.Instance.GetTempNode();
        }
        public void ClearDialogueNode()
        {
            _dialogueNodePos = null;
        }
        public void StopDialogueAfterDistance()
        {
            var distance = CalculateDistance();
            if (distance < 0) return;
            if(distance >= 11)
            {
                GD.Print("Too far");
                DialogueManager.Instance.ForceStopCurrentDialogue();
                _dialogueNodePos = null;
            }
        }
        public override void _Ready()
        {
            DialogueManager.OnDialogueStarted += GetNodes;
            DialogueManager.OnDialogueStoped += ClearDialogueNode;
        }
        public override void _ExitTree()
        {
            DialogueManager.OnDialogueStarted -= GetNodes;
            DialogueManager.OnDialogueStoped -= ClearDialogueNode;
        }
        public override void _Process(double delta)
        {
            StopDialogueAfterDistance();
        }
    }
}
