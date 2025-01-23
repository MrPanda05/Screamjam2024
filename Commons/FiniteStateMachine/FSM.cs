using Godot;
using System;
using System.Collections.Generic;

namespace Commons.FiniteStateMachine
{
    public partial class FSM : Node
    {
        [Export] public NodePath InitialState;

        private Dictionary<string, State> states;
        private State currentState;
        public Action<string> OnStateChangeTo;

        public override void _Ready()
        {
            states = new Dictionary<string, State>();
            foreach (Node node in GetChildren())
            {
                if (node is State state)
                {
                    states[node.Name] = state;
                    state.FiniteStateMachine = this;
                    state.Readys();
                }
            }

            currentState = GetNode<State>(InitialState);
            currentState?.Enter();
        }

        public override void _Process(double delta)
        {
            currentState?.Update((float)delta);
        }
        public override void _PhysicsProcess(double delta)
        {
            currentState?.FixUpdate((float)delta);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            currentState?.HandleInput(@event);
        }
        public void ChangeState(string targetState)
        {
            if (!states.ContainsKey(targetState) || currentState == states[targetState]) return;
            GD.Print("Entering " + targetState);
            OnStateChangeTo?.Invoke(targetState);
            currentState.Exit();
            currentState = states[targetState];
            currentState.Enter();

        }
        public string GetCurrentStateName()
        {
            return currentState.Name;
        }
        public void ForceNullState()
        {
            currentState.Exit();
            currentState = null;
            OnStateChangeTo?.Invoke("null");
            GD.PushWarning($"Object of type {GetParent().Name} is on a null state");
        }
    }
}
