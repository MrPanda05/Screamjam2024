using Godot;
using System;

namespace DialogueSystem
{
	public partial class DialogueBox : Control
	{
		[Export]
		private Label _dialogueLabel;
		[Export]
		private Label _whoLabel;

		public void UpdateDialogue(string dialogue, string speaker)
		{
			_dialogueLabel.Text = dialogue;
			_whoLabel.Text = speaker;
		}
	}
}
