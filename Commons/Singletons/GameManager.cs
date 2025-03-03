using Commons.DialogueSystem;
using Godot;
using System;

namespace Commons.Singletons
{
    public enum GameState
    {
        Playing,
        Paused,
        Fishing,
        Dialogue,
        Other
    }
    /// <summary>
    /// The game manager should keep track of the current state of the game
    /// And is the one that should change the state of the game, where other class ask the game manager to change the state
    /// </summary>
    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        public GameState CurrentState { get; private set; }

        public Action<GameState> OnStateChangeTo;
        public Action OnStateChange;
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void SetStateDialogue()
        {
            CurrentState = GameState.Dialogue;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();
        }
        public void SetStatePlaying()
        {
            CurrentState = GameState.Playing;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();


        }
        public void SetStatePaused()
        {
            CurrentState = GameState.Paused;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();

        }
        public void SetStateOther()
        {
            CurrentState = GameState.Other;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();

        }
        public void SetStateFishing()
        {
            CurrentState = GameState.Fishing;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();

        }
        public void ChangeGameState(GameState newState)
        {
            if(CurrentState == newState) return;
            CurrentState = newState;
            OnStateChangeTo?.Invoke(CurrentState);
            OnStateChange?.Invoke();

        }
    }
}
