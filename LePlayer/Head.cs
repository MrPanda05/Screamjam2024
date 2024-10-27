using Godot;
using InteractSystem;
using System;

namespace LePlayer
{
    public partial class Head : Node3D
    {
        private RayCast3D raycast;

        public void InteractWithObjects()
        {
            if (raycast.GetCollider() is InteractableArea area)
            {

                if (Input.IsActionJustPressed("InteractButton") && area.CanBeInteractWith)
                {
                    area.InvokeInteractions();
                }
            }
        }
        public override void _Ready()
        {
            raycast = GetNode<RayCast3D>("POV/Raycast");
        }


    }
}
