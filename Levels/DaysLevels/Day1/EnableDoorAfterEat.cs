using Commons;
using Godot;
using InteractSystem;
using System;

namespace Levels.Days
{
    /// <summary>
    /// Enables the trigger to open door
    /// </summary>
    public partial class EnableDoorAfterEat : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }



        [Export]
        private Node3D _door;

        public void Interaction()
        {
            _door.ProcessMode = ProcessModeEnum.Inherit;
        }
    }
}
