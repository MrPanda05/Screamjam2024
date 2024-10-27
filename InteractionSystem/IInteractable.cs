using Godot;
using System;

namespace InteractSystem
{
    public interface IInteractable
    {
        InteractableArea Area { get; set; }
        void Interaction();
        Action OnInteraction { get; set; }
    }
}