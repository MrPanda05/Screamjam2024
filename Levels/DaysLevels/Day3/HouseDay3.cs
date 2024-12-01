using Commons.Managers;
using Commons;
using Godot;
using System;

namespace Levels
{
    public partial class HouseDay3 : Node3D
    {
        [Export]
        private Node3D Spawnpoint;
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this, Spawnpoint, Constants.FISHING_DAY3_POOL);

        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
