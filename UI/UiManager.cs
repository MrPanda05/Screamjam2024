using Commons;
using Godot;
using System;
using System.Linq;

namespace Ui
{
    /// <summary>
    /// Instantiate gameui canvaslayer so it is born first
    /// </summary>
    public partial class UiManager : Node
    {
        public static UiManager Instance { get; private set; }
        private GameUi _gameUI;
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            //Create game UI
            _gameUI = (GameUi)GD.Load<PackedScene>(Constants.GAMEUISCENE).Instantiate();
            GetTree().Root.CallDeferred("add_child", _gameUI);
            
        }
    }
}
