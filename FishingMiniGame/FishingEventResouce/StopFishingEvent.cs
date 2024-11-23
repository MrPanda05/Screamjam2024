using FishingMiniGame.DayPool;
using Godot;
using System;

namespace FishingMiniGame.FishingEventResouce
{
    [GlobalClass]
    public partial class StopFishingEvent : BaseFishingEvent
    {
        [Export]
        private int _maxFishCount;

        public StopFishingEvent() { }
        public override void LeEvent(FishPoolResource fishPool, uint fishCount, FishType fishType)
        {
            if (fishCount > _maxFishCount)
            {
                GD.Print("PleaseStop fishing you faggot");
                FishingManager.Instance.StopPlayerFishing();
                //add here thing to enable back home
            }
        }
    }
}
