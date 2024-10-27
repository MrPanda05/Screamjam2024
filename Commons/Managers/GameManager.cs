using Godot;
using System;

namespace Commons.Managers
{
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }
        public static bool IsPlaying { get; private set; }//used to manage the cursor

        public static Action OnIsPlayingChanged;
        public override void _Ready()
        {
            Instance = this;
        }
        public static void SetIsPlaying(bool newValue)
        {
            IsPlaying = newValue;
            OnIsPlayingChanged?.Invoke();
        }
    }
}
