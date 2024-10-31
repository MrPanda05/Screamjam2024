using DialogueSystem;
using Godot;
using System;
using System.Linq;

namespace Ui
{
	public partial class GameUi : CanvasLayer
	{

        [Export]
        public DialogueBox DialogueBoxNode { get; private set; }

        public void SetVisibilityDialogueBox(bool visibility)
        {
            DialogueBoxNode.Visible = visibility;
        }
        public override void _Ready()
        {
            foreach (Control item in GetChildren().Cast<Control>())
            {
                item.Visible = false;
            }
            GD.Print(DialogueBoxNode.Name);
        }
    }
}
