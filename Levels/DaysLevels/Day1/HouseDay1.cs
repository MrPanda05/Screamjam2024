using Commons;
using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    public partial class HouseDay1 : Node3D
    {
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this, Vector3.Zero, Constants.FISHING_DAY1_POOL);

        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
