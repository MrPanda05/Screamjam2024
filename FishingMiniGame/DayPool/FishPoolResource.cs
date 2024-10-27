using Godot;
using Godot.Collections;
using FishingMiniGame.Fishes;
using FishingMiniGame.FishingEventResouce;

namespace FishingMiniGame.DayPool
{
    /// <summary>
    /// A resouce that has a list of fish, name and an event
    /// </summary>
    [GlobalClass]
    public partial class FishPoolResource : Resource
    {
        [Export]
        public Array<FishResource> LeFishResources { get; set; }
        [Export]
        public BaseFishingEvent MyEvent { get; set; }
        [Export]
        public string Name { get; set; }

        public FishPoolResource() : this(null,null, "") { }

        public FishPoolResource(Array<FishResource> fishResources, BaseFishingEvent myEvent, string name)
        {
            LeFishResources = fishResources;
            MyEvent = myEvent;
            Name = name;
        }
    }
}
