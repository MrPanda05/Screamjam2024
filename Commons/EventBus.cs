using Godot;
using System;

namespace Commons
{
    /// <summary>
    /// FAILURE DO NOT USE
    /// </summary>
    public partial class EventBus : Node
    {
        public static EventBus Instance { get; private set; }
        public Action<int> OnEventCalled;
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void InvokeEventById(int id = -1)
        {
            if (id == -1) return;
            OnEventCalled?.Invoke(id);
        }
    }
}
