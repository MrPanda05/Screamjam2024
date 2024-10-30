using Godot;
using System;

namespace Commons
{
    public enum GameState
    {
        PLAYING,//used if the player is active playing
        PAUSED,//used if the game is paused by the playing while in the playing state
        OTHER//used if the game is on a tittle screen or
    }
    public partial class Constants : Node
    {
        public static Constants Instance { get; private set; }

        public static readonly string PLAYER_MOVEMENT_STATE = "PlayerMovementState";
        public static readonly string FISHING_STATE = "FishingState";
        public static readonly string FISHING_DAY1_POOL = "res://FishingMiniGame/DayPool/Day1.tres";
        public static readonly string FISHING_DAY2_POOL = "res://FishingMiniGame/DayPool/Day2.tres";
        public static readonly string FISHING_DAY3_POOL = "res://FishingMiniGame/DayPool/Day3.tres";
        public static readonly string FISHING_CORPSE_POOL = "res://FishingMiniGame/DayPool/Corpse.tres";
        public static readonly string GAMEUISCENE = "res://UI/GameUi.tscn";





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
