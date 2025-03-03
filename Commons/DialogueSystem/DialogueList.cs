using Commons.InteractionSystem;
using Godot;
using Godot.Collections;
using Microsoft.VisualBasic;
using System;

namespace Commons.DialogueSystem
{
    public partial class DialogueList : Node
    {
        [Export]
        public Array<Dialogue> dialogues = new Array<Dialogue>();

        public override void _Ready()
        {
            DialogueBox.OnDialogueExit += OnDialogueEnd;

        }

        public void OnDialogueEnd()
        {
            foreach (var item in GetChildren())
            {
                if (item is IInteractable interactable)
                {
                     interactable.Interact();
                }

            }
        }

        public void SetDialogue(Array<Dialogue> newDialogue)
        {
            dialogues = newDialogue;
        }

        public override void _ExitTree()
        {
            DialogueBox.OnDialogueExit -= OnDialogueEnd;
        }

    }
}
