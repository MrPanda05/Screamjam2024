using Commons;
using Godot;
using InteractSystem;
using System;

namespace InteractSystem.Interactablos
{
    /// <summary>
    /// Make you eat anything hm... uwwu
    /// </summary>
    public partial class EatInteractable : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }


        public void Interaction()
        {
            GD.Print("Yummy");
            GetParent().GetParent().QueueFree();
        }
    }
}
