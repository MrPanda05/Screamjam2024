using Godot;
using InteractSystem;
using LePlayer;
using System;
using Commons;

namespace FishingMiniGame
{
    public partial class EnterFishing : Node3D, IInteractable
    {
        public Action OnInteraction { get; set; }

        [Export]
        public InteractableArea Area { get; set; }

        public void Interaction()
        {
            if (FishingInventoryManager.Instance.HasSeenCorpse) return;
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            player.FSM.TransitioToState(Constants.FISHING_STATE);
        }
        public override void _Ready()
        {
            FishingInventoryManager.Instance.OnHumanHeadCaught += Area.DisableSelf;
        }
        public override void _ExitTree()
        {
            FishingInventoryManager.Instance.OnHumanHeadCaught -= Area.DisableSelf;

        }

    }
}
