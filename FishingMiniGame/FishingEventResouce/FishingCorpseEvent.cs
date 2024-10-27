using FishingMiniGame.DayPool;
using Commons;
using Godot;
using System;

namespace FishingMiniGame.FishingEventResouce 
{
    [GlobalClass]
    public partial class FishingCorpseEvent : BaseFishingEvent
    {
        public FishingCorpseEvent() { }
        public override void LeEvent(FishPoolResource fishPool, uint fishCount, FishType fishType)
        {
            if(fishCount > 2)
            {
                GD.Print("Corpse pool");
                FishingPoolManager.Instance.ChangeCurrentPool(Constants.FISHING_CORPSE_POOL);
            }
        }
    }
}

