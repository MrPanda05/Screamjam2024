using Godot;
using System;

namespace InteractSystem
{
    /// <summary>
    /// This interface handles interactions that need an area to work
    /// </summary>
    public interface IInteractable
    {
        InteractableArea Area { get; set; }
        void Interaction();
        Action OnInteraction { get; set; }
    }
}