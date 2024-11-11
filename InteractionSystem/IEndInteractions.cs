using Godot;
using System;

namespace InteractSystem
{
    /// <summary>
    /// This interface is used for interaction that happens after a dialogue has ended
    /// </summary>
    public interface IEndInteractions
    {
        void Interaction();
        Action<int> OnInteraction { get; set; }
        bool CanRepeat { get; set; }
        bool HasBeenUsed { get; set; }
    }
}
