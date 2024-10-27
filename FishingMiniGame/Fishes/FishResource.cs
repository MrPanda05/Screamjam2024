using Godot;
using Microsoft.VisualBasic;
using System;

namespace FishingMiniGame.Fishes
{
    [GlobalClass]
    public partial class FishResource : Resource
    {
        [Export]
        public FishType fishType { get; set; }
        public FishResource() : this(FishType.Tuna) { }

        public FishResource(FishType fishTypes)
        {
            fishType = fishTypes;
        }
    }
}
