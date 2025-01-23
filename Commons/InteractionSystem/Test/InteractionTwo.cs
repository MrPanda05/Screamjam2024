using Godot;
using System;

namespace Commons.InteractionSystem.Test
{
    public partial class InteractionTwo : BaseInteraction, IInteractable
    {
        public void Interact()
        {
            GD.Print("SecondNode");
        }
    }
}

