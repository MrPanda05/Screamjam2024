using Godot;
using System;

namespace InteractSystem.Interactablos
{
    public partial class Tesxt2 : Node3D, IInteractable
    {
        public Action OnInteraction { get; set; }
        public InteractableArea Area { get ; set; }

        public void Interaction()
        {
            GD.Print("I got interaect");
            OnInteraction?.Invoke();
        }
    }
}
