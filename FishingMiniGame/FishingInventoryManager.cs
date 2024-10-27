using Godot;
using LePlayer;
using System;
using Commons;

namespace FishingMiniGame
{
    
    /// <summary>
    /// Maneges the inventory
    /// </summary>
    public partial class FishingInventoryManager : Node
    {
        public static FishingInventoryManager Instance { get; private set; }
        public uint FishesCaughtTotal { get; set; }
        public uint TunaCaught {  get; set; }
        public uint TilapiaCaught { get; set; }
        public uint CarpaCaught {  get; set; }
        public uint SalmonCaught { get; set; }

        public bool HasSeenCorpse { get; private set; }

        public Action<FishType> OnFishCaught;
        public Action OnHumanHeadCaught;
        private void IncrementCounter(FishType fishType)
        {
            switch (fishType)
            {
                case FishType.Tuna:
                    TunaCaught++;
                break;
                case FishType.Tilapia:
                    TilapiaCaught++;
                break;
                case FishType.Carpa:
                    CarpaCaught++;
                break;
                case FishType.Salmon:
                    SalmonCaught++;
                break;
            }
            FishesCaughtTotal++;
        }
        //Increment counter based on what fish was caught, if the type is other, trigger to exit fishing
        public void CaughtFish(FishType fishType)
        {
            if (fishType == FishType.NULL) return;
            if (fishType == FishType.other) 
            {
                HasSeenCorpse = true;
                OnHumanHeadCaught?.Invoke();
                var player = GetTree().GetFirstNodeInGroup("Player") as Player;
                player.FSM.TransitioToState(Constants.PLAYER_MOVEMENT_STATE);
                GD.Print("fUCKFUCK");
                return;
            }//human head change state back to run
            IncrementCounter(fishType);
            OnFishCaught?.Invoke(fishType);
        }
        public void ResetCounters()
        {
            SalmonCaught = 0;
            TunaCaught = 0;
            TilapiaCaught = 0;
            CarpaCaught = 0;
            FishesCaughtTotal = 0;
        }
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }
    }
}
