using Godot;
using InteractSystem;
using System;

namespace Commons
{
    public partial class IEndDisableObjects : Node3D, IEndInteractions
    {
        public Action<int> OnInteraction { get; set; }
        [Export]
        public bool CanRepeat { get; set; } = false;
        [Export]
        public bool HasBeenUsed { get; set; }

        [Export]
        private Node3D _myObject;

        [Export]
        private bool _visibility;

        [Export]
        private ProcessModeEnum _processMode;

        public void Interaction()
        {
            GD.Print(Name);
            _myObject.Visible = _visibility;
            _myObject.ProcessMode = _processMode;
            HasBeenUsed = true;
        }
    }
}
