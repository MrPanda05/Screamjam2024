using Commons.DialogueSystem;
using Commons.FiniteStateMachine;
using Commons.Singletons;
using Godot;
using System;

namespace Game.Player.States
{
    public partial class InDialogueState : State
    {
        private LePlayer _player;
        public override void Readys()
        {
            _player = GetParent().GetParent<LePlayer>();
        }
        public void SwitchToMovement(GameState gameState)
        {
            if(gameState == GameState.Playing)
            {
                _player.FiniteStateMachine.ChangeState("PlayerMovementState");
            }
        }
        public override void Enter()
        {
            _player.AllowMouseMovement(true);
            GameManager.Instance.OnStateChangeTo += SwitchToMovement;
        }
        public override void Exit()
        {
            _player.AllowMouseMovement(false);
            GameManager.Instance.OnStateChangeTo -= SwitchToMovement;
        }
        public override void HandleInput(InputEvent @event)
        {
            _player.CameraMovement(@event);
        }
    }
}
