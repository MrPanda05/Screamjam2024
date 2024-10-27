using Godot;
using System;

namespace FishingMiniGame
{
    /// <summary>
    /// Maneges the fishing minigame
    /// </summary>
    public partial class FishingManager : Node
    {
        public static FishingManager Instance { get; private set; }
        public bool IsInFishingMode { get; private set; }
        public bool IsActiveFishing { get; private set; }
        public bool FishCaughHook {  get;  private set; }

        private bool isInFishingCouroutine;
        private bool forcedToStop;

        private Timer timerToFishApear;
        private Timer timerToFishEscape;

        public void InverteIfIsFishing()
        {
            IsActiveFishing = !IsActiveFishing;
        }
        public void EnterFishingMode()
        {
            IsInFishingMode = true;
            IsActiveFishing = false;

        }
        public void ExitFishingMode()
        {
            IsInFishingMode = false;
            IsActiveFishing = false;
        }
        private void ThrowFishRod()
        {
            //play sound and animation;
            InverteIfIsFishing();
            StartFishingCouroutine();
            GD.Print("Time to fish");
        }
        private void TryCatchFish()
        {

            InverteIfIsFishing();
            if (timerToFishEscape.TimeLeft <= 0 && timerToFishApear.TimeLeft <= 0 && !FishCaughHook)
            {
                GD.Print("Hook to late, fishu escaped");
                //feed back to the player
                return;
            }
            if (timerToFishApear.TimeLeft > 0 || !FishCaughHook)
            {
                GD.Print("Hook to early, no fishu");
                ForceStopTimer(timerToFishEscape);
                ForceStopTimer(timerToFishApear);
                return;
            }
            if (FishCaughHook)
            {
                ForceStopTimer(timerToFishEscape);
                ForceStopTimer(timerToFishApear);
                GD.Print("Got fishu");
                FishType fishType = FishingPoolManager.Instance.GetFishFromTheCurrentPool();
                FishingInventoryManager.Instance.CaughtFish(fishType);
                return;
            }


        }
        public void SelectFishingAction()
        {
            //Will handle if player wants to start fishing or to catch fish
            if (IsActiveFishing)//means player is fishing right now and wnats to catch the fish
            {
                TryCatchFish();

            }
            else//means player wants to start fishing
            {
                ThrowFishRod();
            }
        }
        public void OnTimerToFishApearTimeout()
        {
            if (forcedToStop) return;
            FishCaughHook = true;
            var rng = new RandomNumberGenerator();
            timerToFishEscape.Start((double)rng.RandfRange(1.5f, 3f));
            GD.Print("Fish caught on hoook, now catch it");
        }
        public void OnTimerToFishEscapeTimeout()
        {
            if(forcedToStop) return;
            FishCaughHook = false;
            GD.Print("fISH Escaped");
        }
        //start fishing logic
        public void StartFishingCouroutine()
        {
            if (!IsActiveFishing) return;
            if (!IsInFishingMode) return;
            var rng = new RandomNumberGenerator();
            isInFishingCouroutine = true;
            timerToFishApear.Start((double)rng.RandfRange(0.5f, 2f));
            GD.Print("Fishing Couroutine started");
        }
        //force a timer to stop and not trigger its event
        public void ForceStopTimer(Timer timer)
        {
            forcedToStop = true;
            timer.Stop();
            forcedToStop = false;
        }


        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            timerToFishApear = GetNode<Timer>("TimerToFishApear");
            timerToFishEscape = GetNode<Timer>("TimerToFishEscape");
        }


    }
}
