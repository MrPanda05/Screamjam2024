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
        private FishPoolResource _fishPool;//Current day fish pool

        //Get random fish from the current pool
        public FishType GetFishFromTheCurrentPool()
        {
            int poolSize = _fishPool.LeFishResources.Count;
            var rng = new RandomNumberGenerator();
            uint randFishNum = rng.Randi() % (uint)poolSize;
            GD.Print(_fishPool.LeFishResources[(int)randFishNum].fishType);
            return _fishPool.LeFishResources[(int)randFishNum].fishType;

        }
        public void SetCurrentPool(string path)
        {
            _fishPool = GD.Load<FishPoolResource>(path);
        }
        public FishPoolResource GetCurrentResouce()
        {
            return _fishPool;
        }
        public void ChangeCurrentPool(string path)
        {
            _fishPool = GD.Load<FishPoolResource>(path);
        }
        /// <summary>
        /// trigger something after a fish is caught
        /// </summary>
        /// <param name="fishType">type of fish caught</param>
        public void TriggerEventOfFishingPool(FishType fishType)
        {
            _fishPool.MyEvent?.LeEvent(_fishPool, FishingInventoryManager.Instance.FishesCaughtTotal, fishType);
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
