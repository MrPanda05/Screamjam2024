using Godot;
using System;

namespace Commons.DialogueSystem
{
    public partial class DialogueBox : Control
    {
        private DialogueList _currentDialogue;

        [Export]
        private Label _authorLabel, _textLabel;

        public int index = 0;
        public int maxIndex = 0;

        public Action OnDialogueEnd;

        public void StartDialgoue(DialogueList dialogue)
        {
            _currentDialogue = dialogue;
            _currentDialogue.Connect(this);
            _textLabel.Visible = true;
            maxIndex = _currentDialogue._dialogues.Count;
            _authorLabel.Text = _currentDialogue._dialogues[index].Author;
            _textLabel.Text = _currentDialogue._dialogues[index].Text;
        }
        public void NextDialogue()
        {
            index++;
            if(index >= maxIndex)
            {
                OnDialogueEnd?.Invoke();
                _currentDialogue.Disconnect(this);
                _currentDialogue = null;
                _textLabel.Visible = false;
                GD.Print("Dialogue End");
                index = 0;
                return;
            }
            GD.Print("Next dialogue");
            _authorLabel.Text = _currentDialogue._dialogues[index].Author;
            _textLabel.Text = _currentDialogue._dialogues[index].Text;
        }
        public override void _PhysicsProcess(double delta)
        {
            if (_currentDialogue == null) return;
            if (Input.IsActionJustPressed("InteractButton"))
            {
                NextDialogue();
            }
        }
    }
}
