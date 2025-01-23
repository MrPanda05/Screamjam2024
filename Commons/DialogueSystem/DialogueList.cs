using Godot;
using Godot.Collections;
using System;

namespace Commons.DialogueSystem
{
    public partial class DialogueList : Node
    {
        [Export]
        public Array<Dialogue> _dialogues = new Array<Dialogue>();
       
        public void OnDialogueEnd()
        {
            GD.Print("My dialogue ended");

        }
        public void Connect(DialogueBox dialogueBox)
        {
            dialogueBox.OnDialogueEnd += OnDialogueEnd;
            GD.Print("Conected");
        }
        public void Disconnect(DialogueBox dialogueBox)
        {
            dialogueBox.OnDialogueEnd -= OnDialogueEnd;
            GD.Print("Disconnected");
        }

    }
}
