using Godot;
using System;

namespace Commons.InteractionSystem.Test
{
    public partial class InteractionTest : BaseInteraction, IInteractable
    {
        public Action OnTest;
        public void Interact()
        {
            OnBaseInteraction?.Invoke();
            OnTest?.Invoke();
            GD.Print("First node");
        }
        
    }
}
