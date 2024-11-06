using Commons;
using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    public partial class HouseDay1 : Node3D
    {
        [Export]
        private Node3D Spawnpoint;
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this, Spawnpoint, Constants.FISHING_DAY1_POOL);

        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
