using Godot;
using System;

namespace Commons.TriggerSystem
{
    public interface ITrigger
    {
        void Trigger(Node affectedNode);
    }
}
