using Godot;
using System;

namespace Commons
{
    public partial class Constants : Node
    {
        public static Constants Instance { get; private set; }

        public static readonly string PLAYER_MOVEMENT_STATE = "PlayerMovementState";
        public static readonly string FISHING_STATE = "FishingState";
        public static readonly string FISHING_DAY1_POOL = "res://FishingMiniGame/DayPool/Day1.tres";
        public static readonly string FISHING_DAY2_POOL = "res://FishingMiniGame/DayPool/Day2.tres";
        public static readonly string FISHING_DAY3_POOL = "res://FishingMiniGame/DayPool/Day3.tres";
        public static readonly string FISHING_CORPSE_POOL = "res://FishingMiniGame/DayPool/Corpse.tres";





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
