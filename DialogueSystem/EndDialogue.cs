using DialogueSystem.DiaResource;
using Godot;
using InteractSystem;
using System;

namespace DialogueSystem
{
    /// <summary>
    /// Trigger something after an NPC dialogue has ended
    /// </summary>
    public partial class EndDialogue : Node3D
    {
        private DialogueResource _myDialogue;
        private StartDialogue _myStartDialogue;

        public void StartEndDialogues(int id)
        {
            if (id != _myDialogue.MyId) return;
            foreach (var item in GetChildren())
            {
                if (item is IEndInteractions interactable && (interactable.CanRepeat || !interactable.HasBeenUsed))
                {
                    interactable.Interaction();
                }
            }

        }

        public override void _Ready()
        {
            _myStartDialogue = GetParent<StartDialogue>();
            _myDialogue = _myStartDialogue.MyDialogue;
            _myDialogue.OnDialogueEnded += StartEndDialogues;
        }
        public override void _ExitTree()
        {
            _myDialogue.OnDialogueEnded -= StartEndDialogues;
        }
    }
}
