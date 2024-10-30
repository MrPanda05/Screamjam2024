using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    public partial class FishingSpot : Node3D
    {
        [Export]
        public Node3D spawnPosition;
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
