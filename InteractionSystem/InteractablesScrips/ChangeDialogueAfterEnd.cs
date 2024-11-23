using DialogueSystem;
using DialogueSystem.DiaResource;
using Godot;
using InteractSystem;
using System;

namespace InteractSystem
{
    public partial class ChangeDialogueAfterEnd : Node3D, IEndInteractions
    {
        public Action<int> OnInteraction { get; set ; }
        public bool CanRepeat { get; set; }
        public bool HasBeenUsed { get; set; }

        [Export]
        private StartDialogue _dialogueBox;

        [Export]
        private DialogueResource _newDialogue;
        public void Interaction()
        {
            _dialogueBox.ChangeDialogue(_newDialogue);
        }
    }
}
