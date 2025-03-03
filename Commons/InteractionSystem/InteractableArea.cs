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
        //Maybe change this
        [Export]
        private bool _disableForAshortTime;
        public bool CanBeInteractWith { get; private set; }

        public Action OnInteraction;
        private void UpdateInteraction()
        {
            CanBeInteractWith = isRepeatable || !hasBeenUsed;
        }

        public async void InvokeInteract()
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
            if (_disableForAshortTime)
            {
                ProcessMode = ProcessModeEnum.Disabled;
                await ToSignal(GetTree().CreateTimer(2f), Timer.SignalName.Timeout);
                ProcessMode = ProcessModeEnum.Inherit;

            }
        }

        public override void _Ready()
        {
            UpdateInteraction();
        }
    }
}
