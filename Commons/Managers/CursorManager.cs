using Godot;
using System;

namespace Commons.Managers 
{ 
    public partial class CursorManager : Node
    {
        public static CursorManager Instance { get; private set; }

        public override void _Ready()
        {
            if(Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void EnableCursor()
        {
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }
        public void DisableCursor()
        {
            Input.MouseMode = Input.MouseModeEnum.Hidden;
        }
        public void CaptureCursor()
        {
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
    }
}
