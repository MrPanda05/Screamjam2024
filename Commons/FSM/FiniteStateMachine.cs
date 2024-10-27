using Godot;
using System;
using System.Collections.Generic;

namespace Commons.FSM
{
    public partial class FiniteStateMachine : Node
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
                if (node is State s)
                {
                    states[node.Name] = s;
                    s.FSM = this;
                    s.Readys();
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
        public void TransitioToState(string key)
        {
            if (!states.ContainsKey(key) || currentState == states[key]) return;
            GD.Print("Entering " + key);
            OnStateChangeTo?.Invoke(key);
            currentState.Exit();
            currentState = states[key];
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
        }
    }
}
