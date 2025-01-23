using Commons.InteractionSystem;
using Godot;
using System;

namespace Commons.DialogueSystem
{
    public partial class StartDialogue : BaseInteraction, IInteractable
    {
        [Export]
        private DialogueList _dialogueList;
        public void Interact()
        {
            var dialogueBox = GetTree().GetFirstNodeInGroup("DialogueCanvas").GetChild<DialogueBox>(0);
            dialogueBox.StartDialgoue(_dialogueList);
        }
    }
}
