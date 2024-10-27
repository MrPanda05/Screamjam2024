using Godot;
using System;

namespace Commons.FSM
{
    public partial class State : Node
    {
        public FiniteStateMachine FSM;
        public virtual void Readys() { }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update(float delta) { }
        public virtual void FixUpdate(float delta) { }
        public virtual void HandleInput(InputEvent @event) { }
    }
}
