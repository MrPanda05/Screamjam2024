using Godot;
using Microsoft.VisualBasic;
using System;

namespace FishingMiniGame.Fishes
{
    /// <summary>
    /// Generic fish, used to create new fish
    /// </summary>
    [GlobalClass]
    public partial class FishResource : Resource
    {
        [Export]
        public FishType fishType { get; set; }
        public FishResource() : this(FishType.NULL) { }

        public FishResource(FishType fishTypes)
        {
            fishType = fishTypes;
        }
    }
}
