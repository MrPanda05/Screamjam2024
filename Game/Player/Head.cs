using Commons.InteractionSystem;
using Godot;
using System;

namespace Game.Player
{
    public partial class Head : Node3D
    {
        public Camera3D PlayerCamera { get; private set; }
        [Export]
        private RayCast3D _raycast;

        private bool _isInteractionEnabled = true;

        private LePlayer _player;

        public override void _Ready()
        {
            PlayerCamera = GetNode<Camera3D>("PlayerCamera");
            _player = GetParent<LePlayer>();
        }

        public void EnableInteraction()
        {
            _isInteractionEnabled = true;
        }
        public void DisableInteraction()
        {
            _isInteractionEnabled = false;
        }
        /// <summary>
        /// Interacts with interactbles on the scene
        /// </summary>
        public void InteractWithObjects()
        {
            if (!_isInteractionEnabled) return;
            if (_raycast.GetCollider() is InteractableArea area && area.CanBeInteractWith)
            {
                if (Input.IsActionJustPressed("InteractButton"))
                {
                    area.InvokeInteract();
                }
            }
        }
    }
}
