using FishingMiniGame.DayPool;
using Godot;
using System;

namespace FishingMiniGame.FishingEventResouce
{
    public partial class BaseFishingEvent : Resource
    {
        public virtual void LeEvent(FishPoolResource fishPool = null, uint fishCount = 0, FishType fishType = FishType.NULL) { }


        public BaseFishingEvent() { }
    }
}
