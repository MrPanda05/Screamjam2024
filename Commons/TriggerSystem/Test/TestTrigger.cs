using Game.Player;
using Godot;
using System;

namespace Commons.TriggerSystem.Test
{
    public partial class TestTrigger : Node3D, ITrigger
    {
        public void Trigger(Node affectedNode)
        {
            LePlayer player = affectedNode as LePlayer;
            GD.Print("Triggered");
            player.FiniteStateMachine.ForceNullState();
        }
    }
}
