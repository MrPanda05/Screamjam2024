using FishingMiniGame;
using Godot;
using System;
using System.Linq;

namespace InteractSystem
{
    /// <summary>
    /// Used for things interactable by the player with the E key, uses IInteractable and NOT IEndInteractable
    /// </summary>
    public partial class InteractableArea : Area3D
    {
        [Export]
        public bool canRepeat;
        public bool hasBeenUsed;
        public bool CanBeInteractWith { get; private set; }

        public void DisableSelf()
        {
            ProcessMode = ProcessModeEnum.Disabled;
        }
        public void EnableSelf()
        {
            ProcessMode = ProcessModeEnum.Inherit;
        }
        public void EnableRepetition()
        {
            canRepeat = true;
        }
        public void DisableRepetition()
        {
            canRepeat = false;
        }
        public void UpdateInteraction()
        {
            CanBeInteractWith = canRepeat || !hasBeenUsed;

            if (!CanBeInteractWith)
            {
                DisableSelf();
            }
        }

        public void InvokeInteractions()
        {
            UpdateInteraction();
            if (!CanBeInteractWith) return;
            foreach (var item in GetChildren())
            {
                if (item is IInteractable interactable)
                {
                    interactable.Interaction();
                }
            }
            hasBeenUsed = true;
            UpdateInteraction();
        }
        public override void _Ready()
        {
            UpdateInteraction();
        }
        public override void _PhysicsProcess(double delta)
        {
            //GD.Print($"Can Repeat? {canRepeat}");
            //GD.Print($"Has been used? {hasBeenUsed}");
            //GD.Print($"Can interact? {CanBeInteractWith}");

        }
    }
}
