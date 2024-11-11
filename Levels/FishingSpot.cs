using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    /// <summary>
    /// Initialize the fishing spot
    /// </summary>
    public partial class FishingSpot : Node3D
    {
        [Export]
        public Node3D spawnPosition;
        //todo add a resource that tell how the day will be?????
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this, spawnPosition);

        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
