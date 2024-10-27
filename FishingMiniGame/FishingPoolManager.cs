using FishingMiniGame.DayPool;
using Godot;
using Commons;
using LePlayer;
using System;

namespace FishingMiniGame
{
    public enum FishType
    {
        Tuna,
        Tilapia,
        Carpa,
        Salmon,
        other,
        NULL
    }
    public partial class FishingPoolManager : Node
    {
        public static FishingPoolManager Instance { get; private set; }
        [Export]
        private FishPoolResource fishPool;

        //Get random fish from the current pool
        public FishType GetFishFromTheCurrentPool()
        {
            int poolSize = fishPool.LeFishResources.Count;
            var rng = new RandomNumberGenerator();
            uint randFishNum = rng.Randi() % (uint)poolSize;
            GD.Print(fishPool.LeFishResources[(int)randFishNum].fishType);
            return fishPool.LeFishResources[(int)randFishNum].fishType;

        }
        public void ChangeCurrentPool(string path)
        {
            fishPool = GD.Load<FishPoolResource>(path);
        }
        //Fish pool will have a resource that has a variable
        public void TriggerEventOfFishingPool()
        {
            fishPool?.myEvent.LeEvent(fishPool, FishingInventoryManager.Instance.FishesCaughtTotal);
            //if (fishPool.Name == "Day3" && FishingInventoryManager.Instance.FishesCaughtTotal > 2)
            //{
            //    ChangeCurrentPool(Constants.FISHING_CORPSE_POOL);
            //}
        }
        public override void _Ready()
        {
            Instance = this;
            GD.Print(fishPool.Name);
            FishingInventoryManager.Instance.OnFishCaught += TriggerEventOfFishingPool;
        }
        public override void _ExitTree()
        {
            FishingInventoryManager.Instance.OnFishCaught -= TriggerEventOfFishingPool;
        }
    }
}
