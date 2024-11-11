using Godot;
using InteractSystem;
using System;

namespace Commons
{
    /// <summary>
    /// Can disable or turn invisible any node3D
    /// </summary>
    public partial class DisableAnyObject : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        [Export]
        private Node3D _myObject;

        [Export]
        private bool _visibility;

        [Export]
        private ProcessModeEnum _processMode;
        public void Interaction()
        {
            _myObject.Visible = _visibility;
            _myObject.ProcessMode = _processMode;
        }
    }
}
