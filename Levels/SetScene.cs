using Godot;
using System;
using Commons.Managers;
using InteractSystem.Interactablos;

namespace Levels
{
    public partial class SetScene : Node3D
    {
        private string _NextScene;
        [Export]
        public TriggerChangeScene scene;

        public override void _Ready()
        {
            _NextScene = GameManager.Instance.GetNextDayScene();
            GD.Print(_NextScene);
            scene.path = _NextScene;

        }
    }
}
