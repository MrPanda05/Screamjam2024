using FishingMiniGame;
using FishingMiniGame.DayPool;
using Godot;
using LePlayer;
using System;

namespace Commons.Managers
{
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }
        public GameState CurrentState { get; private set; }

        public static Action<GameState> OnGameStateChange;

        private Node3D _currentActiveScene;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            //SetCurrentGameState(GameState.OTHER);Default state, as game start on tittle scren
        }
        private void SetCurrentGameState(GameState newState)
        {
            if (newState == CurrentState) return;
            CurrentState = newState;
            OnGameStateChange?.Invoke(newState);
        }
        public void Pause()
        {
            if(CurrentState == GameState.OTHER || CurrentState == GameState.PAUSED) return;
            if(CurrentState == GameState.PLAYING)
            {
                GD.Print("Pause");
            }
        }
        public void UnPause()
        {
            if (CurrentState == GameState.OTHER || CurrentState == GameState.PLAYING) return;
            if (CurrentState == GameState.PAUSED)
            {
                GD.Print("UnPause");
            }
        }
        /// <summary>
        /// This will be called by the START button
        /// </summary>
        public void StartPlaying()
        {
            SetCurrentGameState(GameState.PLAYING);
        }
        /// <summary>
        /// This will be called if the player exit the game to tittle screen, or credits
        /// </summary>
        public void EnterOtherState()
        {
            SetCurrentGameState(GameState.OTHER);
        }

        private void SetCurrentActiveScene(Node3D currentScene)
        {
            if (_currentActiveScene != null) return;
            _currentActiveScene = currentScene;
        }
        public void ChangeCurrentScene(string path)
        {
            GetTree().ChangeSceneToFile(path);
        }
        public void ChangeCurrentDay(string path)
        {
            FishingPoolManager.Instance.SetCurrentPool(path);
        }
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is not InputEventKey eventKey) return;
            if (eventKey.Pressed && !eventKey.IsEcho() && eventKey.Keycode == Key.Escape)
            {
                
            }
        }

        #region PlayerRelated
        public void RemovePlayerFromScene()
        {
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            _currentActiveScene.RemoveChild(player);
            GetTree().Root.AddChild(player);
        }
        public void AddPlayerToScene()
        {
            if (GetTree().GetFirstNodeInGroup("Player") is not Player player) return;//If player does not exist
            if (_currentActiveScene.FindChild("Player") != null) return;//if player is already on the scene and part of the root
            GetTree().Root.RemoveChild(player);
            _currentActiveScene.AddChild(player);
        }
        private void SetPlayerPosition(Node3D spawnPosition)
        {
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            player.GlobalPosition = spawnPosition.GlobalPosition;
        }
        private void SetPlayerPosition(Vector3 spawnPosition)
        {
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            player.GlobalPosition = spawnPosition;
        }
        private void SetPlayerRotation(Node3D nodeRotation)
        {
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            //Todo fix this
            //player.Camera.GlobalRotation = nodeRotation.GlobalRotation;
            //player.GlobalRotation = nodeRotation.GlobalRotation;

        }
        #endregion

        #region SceneInitialization
        public void InitializeCurrentMainScene(Node3D currentScene)
        {
            SetCurrentActiveScene(currentScene);
            AddPlayerToScene();
        }
        public void InitializeCurrentMainScene(Node3D currentScene, Node3D playerPos)
        {
            SetCurrentActiveScene(currentScene);
            AddPlayerToScene();
            SetPlayerPosition(playerPos);
            SetPlayerRotation(playerPos);
        }
        public void InitializeCurrentMainScene(Node3D currentScene, Vector3 playerPos)
        {
            SetCurrentActiveScene(currentScene);
            AddPlayerToScene();
            SetPlayerPosition(playerPos);
        }
        public void InitializeCurrentMainScene(Node3D currentScene, Node3D playerPos, string day)
        {
            SetCurrentActiveScene(currentScene);
            AddPlayerToScene();
            SetPlayerPosition(playerPos);
            ChangeCurrentDay(day);
        }
        public void InitializeCurrentMainScene(Node3D currentScene, Vector3 playerPos, string day)
        {
            SetCurrentActiveScene(currentScene);
            AddPlayerToScene();
            SetPlayerPosition(playerPos);
            ChangeCurrentDay(day);
        }
        #endregion

        #region SceneClearing
        public void ClearCurrentScene()
        {
            _currentActiveScene = null;
        }
        #endregion

    }
}
