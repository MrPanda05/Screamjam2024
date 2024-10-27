using FishingMiniGame.DayPool;
using Godot;
using Commons;
using LePlayer;
using System;

namespace FishingMiniGame
{
    /// <summary>
    /// Enums of types of fish
    /// </summary>
    public enum FishType
    {
        Tuna,
        Tilapia,
        Carpa,
        Salmon,
        other,
        NULL
    }
    /// <summary>
    /// Manages the current day fish pool
    /// </summary>
    public partial class FishingPoolManager : Node
    {
        public static FishingPoolManager Instance { get; private set; }
        [Export]
        private FishPoolResource fishPool;//Current day fish pool

        //Get random fish from the current pool
        public FishType GetFishFromTheCurrentPool()
        {
            int poolSize = fishPool.LeFishResources.Count;
            var rng = new RandomNumberGenerator();
            uint randFishNum = rng.Randi() % (uint)poolSize;
            GD.Print(fishPool.LeFishResources[(int)randFishNum].fishType);
            return fishPool.LeFishResources[(int)randFishNum].fishType;

        }
        public FishPoolResource GetCurrentResouce()
        {
            return fishPool;
        }
        public void ChangeCurrentPool(string path)
        {
            fishPool = GD.Load<FishPoolResource>(path);
        }
        /// <summary>
        /// trigger something after a fish is caught
        /// </summary>
        /// <param name="fishType">type of fish caught</param>
        public void TriggerEventOfFishingPool(FishType fishType)
        {
            fishPool.MyEvent?.LeEvent(fishPool, FishingInventoryManager.Instance.FishesCaughtTotal, fishType);
        }
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            FishingInventoryManager.Instance.OnFishCaught += TriggerEventOfFishingPool;
        }
        public override void _ExitTree()
        {
            FishingInventoryManager.Instance.OnFishCaught -= TriggerEventOfFishingPool;
        }
    }
}
