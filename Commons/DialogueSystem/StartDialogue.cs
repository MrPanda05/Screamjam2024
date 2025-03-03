using Commons.InteractionSystem;
using Commons.Singletons;
using Godot;
using System;

namespace Commons.DialogueSystem
{
    public partial class StartDialogue : BaseInteraction, IInteractable
    {
        [Export]
        private DialogueList _dialogueList;

        [Export]
        private bool _isInnerMonologue;

        public void Interact()
        {
            var dialogueBox = GetTree().GetFirstNodeInGroup("DialogueCanvas").GetChild<DialogueBox>(0);
            if(dialogueBox.IsRunning) return;
            dialogueBox.StartDialgoue(_dialogueList, _isInnerMonologue);
        }
    }
}
