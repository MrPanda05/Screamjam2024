using Commons.Managers;
using Commons;
using Godot;
using System;

namespace Levels
{
    public partial class FestivalDay3 : Node3D
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
