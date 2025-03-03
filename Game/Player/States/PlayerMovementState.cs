using Commons.DialogueSystem;
using Commons.FiniteStateMachine;
using Commons.Singletons;
using Godot;
using System;

namespace Game.Player.States
{
    public partial class PlayerMovementState : State
    {
        private LePlayer _player;
        public override void Readys()
        {
            _player = GetParent().GetParent<LePlayer>();
        }
        public void SwitchToDialogue(GameState gameState)
        {
            if(gameState == GameState.Dialogue)
            {
                _player.FiniteStateMachine.ChangeState("InDialogueState");
            }
        }
        public override void Enter()
        {
            _player.AllowMovement(true);
            _player.AllowMouseMovement(true);
            Input.MouseMode = Input.MouseModeEnum.Captured;
            //DialogueBox.OnDialogueEnter += SwitchToDialogue;
            GameManager.Instance.OnStateChangeTo += SwitchToDialogue;
            _player.HeadNode.EnableInteraction();
        }
        public override void Exit()
        {
            _player.AllowMovement(false);
            _player.AllowMouseMovement(false);
            //DialogueBox.OnDialogueEnter -= SwitchToDialogue;
            GameManager.Instance.OnStateChangeTo -= SwitchToDialogue;
            _player.HeadNode.DisableInteraction();
        }
        public override void FixUpdate(float delta)
        {
            _player.GetInput();
            _player.Move(delta);
            _player.HeadNode.InteractWithObjects();
        }
        public override void HandleInput(InputEvent @event)
        {
            _player.CameraMovement(@event);
        }
    }
}
