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

        //todo add a way to ask the game manager which next scene shall be
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
