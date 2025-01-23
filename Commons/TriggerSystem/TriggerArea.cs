using Commons.InteractionSystem;
using Godot;
using Microsoft.VisualBasic;
using System;

namespace Commons.TriggerSystem
{
	public partial class TriggerArea : Area3D
	{
        [Export]
        public bool isRepeatable = true;
        [Export]
        public bool hasBeenUsed;
        public bool CanBeInteractWith { get; private set; }

        public Action OnInteraction;
        public void OnAreaEntered(Area3D area)
		{
            if (!CanBeInteractWith) return;
            InvokeInteract(area.GetParent());
        }
        private void UpdateInteraction()
        {
            CanBeInteractWith = isRepeatable || !hasBeenUsed;
        }

        public void InvokeInteract(Node affectedNode)
        {
            foreach (var item in GetChildren())
            {
                if (item is ITrigger area)
                {
                    area.Trigger(affectedNode);
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
