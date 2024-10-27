using Godot;
using Godot.Collections;
using FishingMiniGame.Fishes;
using FishingMiniGame.FishingEventResouce;

namespace FishingMiniGame.DayPool
{
    [GlobalClass]
    public partial class FishPoolResource : Resource
    {
        [Export]
        public Array<FishResource> LeFishResources { get; set; }
        [Export]
        public BaseFishingEvent myEvent { get; set; }
        [Export]
        public string Name { get; set; }

        public FishPoolResource() : this(null, "") { }

        public FishPoolResource(Array<FishResource> fishResources, string name)
        {
            LeFishResources = fishResources;
            Name = name;
        }
    }
}
