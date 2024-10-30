using Godot;
using System;
using System.Linq;

namespace Ui
{
	public partial class GameUi : CanvasLayer
	{
        public override void _Ready()
        {
            foreach (Control item in GetChildren().Cast<Control>())
            {
                item.Visible = false;
            }
        }
    }
}
