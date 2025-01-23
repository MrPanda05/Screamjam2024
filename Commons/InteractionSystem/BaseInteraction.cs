using Godot;
using System;

namespace Commons.InteractionSystem
{
    public partial class BaseInteraction : Node
    {
        [Export]
        protected bool IsRepeatable { get; set; }
        [Export]
        protected bool HasBeenUsed { get; set; }
        public bool CanBeInteractWith { get; private set; }

        public InteractableArea Area { get; private set; }

        public Action OnBaseInteraction;
        public void Use()
        {
            HasBeenUsed = true;
            UpdateInteraction();
        }
        private void UpdateInteraction()
        {
            CanBeInteractWith = IsRepeatable || !HasBeenUsed;
        }
        //Do not overriede on inherit class
        public override void _Ready()
        {
            UpdateInteraction();
            Area = GetParent<InteractableArea>();
        }
    }
}
