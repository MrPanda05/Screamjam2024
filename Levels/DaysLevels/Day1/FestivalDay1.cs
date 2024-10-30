using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    public partial class FestivalDay1 : Node3D
    {
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this);
        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
