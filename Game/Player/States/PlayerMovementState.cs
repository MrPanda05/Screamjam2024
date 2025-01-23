using Commons.FiniteStateMachine;
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
        public override void Enter()
        {
            _player.AllowMovement(true);
            _player.AllowMouseMovement(true);
            _player.HeadNode.EnableInteraction();
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
        public override void Exit()
        {
            _player.AllowMovement(false);
            _player.HeadNode.DisableInteraction();
            _player.AllowMouseMovement(false);
            Input.MouseMode = Input.MouseModeEnum.Visible;

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
