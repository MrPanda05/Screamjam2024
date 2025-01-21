using Godot;
using InteractSystem;
using System;
using System.Reflection;

namespace LePlayer
{
    /// <summary>
    /// Control raycast of player and crosshair
    /// </summary>
    public partial class Head : Node3D
    {
        private RayCast3D _raycast;
        [Export]
        private ColorRect _crosshair;

        public void InteractWithObjects()
        {
            if (_raycast.GetCollider() is InteractableArea area && area.CanBeInteractWith)
            {
                //GD.Print($"Can Repeat? {area.canRepeat}");
                //GD.Print($"Has been used? {area.hasBeenUsed}");
                //GD.Print($"Can interact? {area.CanBeInteractWith}");
                _crosshair.Color = new Color(255, 0, 0);
                if (Input.IsActionJustPressed("InteractButton") && area.Visible)
                {
                    area.InvokeInteractions();
                }
            }
            else
            {
                _crosshair.Color = new Color(0, 255, 0);
            }
        }
        public override void _Ready()
        {
            _raycast = GetNode<RayCast3D>("POV/Raycast");
        }


    }
}
