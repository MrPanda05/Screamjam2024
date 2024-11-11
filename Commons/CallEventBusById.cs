using Godot;
using InteractSystem;
using System;

namespace Commons
{
    /// <summary>
    /// FAILURE DO NOT USE
    /// </summary>
    public partial class CallEventBusById : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        [Export]
        private int _myId = -1;

        public void Interaction()
        {
            EventBus.Instance.InvokeEventById(_myId);
        }
    }
}
