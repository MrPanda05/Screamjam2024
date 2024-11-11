using Godot;
using InteractSystem;
using System;

namespace DialogueSystem.Test
{
    public partial class TestEndDialogueInteraction : Node3D, IEndInteractions
    {
        public Action<int> OnInteraction { get; set; }
        [Export]
        public bool CanRepeat { get; set; }
        public bool HasBeenUsed { get; set; }

        public void Interaction()
        {
            GD.Print("END INTERACTION");
            HasBeenUsed = true;
        }
    }
}
