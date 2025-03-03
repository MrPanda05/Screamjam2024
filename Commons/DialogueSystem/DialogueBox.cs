using Commons.Singletons;
using Godot;
using System;
using System.Threading.Tasks;

namespace Commons.DialogueSystem
{
public partial class DialogueBox : Control
    {
        private DialogueList _currentDialogue;
        private bool _isSkipping = false;

        [Export]
        private Label _authorLabel, _textLabel;

        public bool IsRunning { get; private set; }

        public int index = 0;
        public int maxIndex = 0;

        // Used for static use, i.e when someone wants to know if any dialogue started
        public static Action OnDialogueEnter;
        public static Action OnInnerDialogueEnter;
        public static Action OnDialogueExit;

        // Method to show dialogue text with a typing effect
        public async Task<bool> ShowDialogue(string text, float timerSpeed = 0.1f)
        {
            IsRunning = true;
            _textLabel.Text = "";
            foreach (char c in text)
            {
                if (_isSkipping)
                {
                    _textLabel.Text = text;
                    break;
                }
                _textLabel.Text += c;
                await ToSignal(GetTree().CreateTimer(timerSpeed), Timer.SignalName.Timeout);
            }
            IsRunning = false;
            _isSkipping = false;
            return IsRunning;
        }

        // Method to start the dialogue sequence
        public async void StartDialgoue(DialogueList dialogue, bool isInner)
        {
            _currentDialogue = dialogue;
            maxIndex = _currentDialogue.dialogues.Count;
            if (maxIndex <= 0) return;
            if (isInner)
            {
                OnInnerDialogueEnter?.Invoke();
            }
            else
            {
                OnDialogueEnter?.Invoke();
                GameManager.Instance.SetStateDialogue();
            }
            _textLabel.Visible = true;
            _authorLabel.Text = _currentDialogue.dialogues[index].Author;
            await ShowDialogue(_currentDialogue.dialogues[index].Text);
        }

        // Method to proceed to the next dialogue in the sequence
        public async Task NextDialogue()
        {
            index++;
            if (index >= maxIndex)
            {
                _currentDialogue = null;
                _textLabel.Visible = false;
                index = 0;
                OnDialogueExit?.Invoke();
                GameManager.Instance.SetStatePlaying();
                return;
            }
            _authorLabel.Text = _currentDialogue.dialogues[index].Author;
            await ShowDialogue(_currentDialogue.dialogues[index].Text);
        }

        public override async void _PhysicsProcess(double delta)
        {
            if (_currentDialogue == null) return;
            if (Input.IsActionJustPressed("InteractButton"))
            {
                if (IsRunning)
                {
                    _isSkipping = true;
                }
                else
                {
                    await NextDialogue();
                }
            }
        }
    }
}
