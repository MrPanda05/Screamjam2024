using Godot;
using System;

namespace DialogueSystem
{

	/// <summary>
	/// Has all the dialogue boxes used for the dialogue system
	/// </summary>
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

		public void UpdateMonologue(string monologue)
		{
            _dialogueLabel.Text = monologue;
            _whoLabel.Text = "You";
        }
	}
}
