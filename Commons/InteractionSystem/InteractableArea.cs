using Godot;
using System;

namespace Commons.InteractionSystem
{
	public partial class InteractableArea : Area3D
	{
        [Export]
        public bool isRepeatable = true;
        [Export]
        public bool hasBeenUsed;
        public bool CanBeInteractWith { get; private set; }

        public Action OnInteraction;
        private void UpdateInteraction()
        {
            CanBeInteractWith = isRepeatable || !hasBeenUsed;
        }

        public void InvokeInteract()
		{
            if(!CanBeInteractWith) return;

            foreach (var item in GetChildren())
            {
                if (item is IInteractable interactable && item is BaseInteraction baseInteraction)
                {
                    if(baseInteraction.CanBeInteractWith)
                    {
                        interactable.Interact();
                        baseInteraction.Use();
                    }
                }
                
            }
            hasBeenUsed = true;
            UpdateInteraction();
            OnInteraction?.Invoke();
        }

        public override void _Ready()
        {
            UpdateInteraction();
        }
    }
}
