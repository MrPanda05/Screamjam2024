using Godot;
using System;
using Commons.FSM;

namespace LePlayer.States
{
    public partial class PlayerMovementState : State
    {
        private Player LePlayer;
        private Head head;

        public override void Readys()
        {
            LePlayer = GetParent().GetParent<Player>();
            head = GetNode<Head>("../../Head");
        }

        public override void HandleInput(InputEvent @event)
        {
            LePlayer.PlayerMouseMovement(@event);
        }
        public override void FixUpdate(float delta)
        {
            LePlayer.ControlPlayer(delta);
        }
        public override void Update(float delta)
        {
            head.InteractWithObjects();
        }
    }
}
