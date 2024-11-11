using DialogueSystem;
using Godot;
using InteractSystem;
using System;

namespace Models
{

    /// <summary>
    /// Possible door to make open door animation possible
    /// </summary>
    public partial class DoorAxis : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        [Export]
        private AnimationPlayer _anim;
        [Export]
        private Timer _timer;

        private bool _isOpen;


        public override void _Ready()
        {
            Area = GetParent<InteractableArea>();
        }

        private void OpenDoor()
        {
            if (_isOpen) return;
            if (_anim.IsPlaying()) return;

        }








        public void Interaction()
        {
            throw new NotImplementedException();
        }
        
    }
}
