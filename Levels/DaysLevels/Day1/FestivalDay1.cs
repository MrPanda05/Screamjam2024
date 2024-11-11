using Commons.Managers;
using Godot;
using System;

namespace Levels.Days
{
    /// <summary>
    /// Initialize day 1 of the festival
    /// </summary>
    public partial class FestivalDay1 : Node3D
    {
        [Export]
        private Node3D _spawnpoint;
        public override void _Ready()
        {
            GameManager.Instance.InitializeCurrentMainScene(this, _spawnpoint);
        }
        public override void _ExitTree()
        {
            GameManager.Instance.ClearCurrentScene();
        }
    }
}
