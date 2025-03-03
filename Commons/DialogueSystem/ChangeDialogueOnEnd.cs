using Commons.InteractionSystem;
using Godot;
using Godot.Collections;
using System;

namespace Commons.DialogueSystem
{
    public partial class ChangeDialogueOnEnd : Node, IInteractable
    {
        [Export]
        protected bool IsRepeatable { get; set; }
        [Export]
        protected bool HasBeenUsed { get; set; }
        public bool CanBeInteractWith { get; private set; }


        [Export]
        public Array<Dialogue> newDialogue = new Array<Dialogue>();

        private void UpdateInteraction()
        {
            CanBeInteractWith = IsRepeatable || !HasBeenUsed;
        }
        public void Interact()
        {
            if(!CanBeInteractWith) return;
            GD.Print("Chaged dialogue to a new list");
            var dilogueList = GetParent<DialogueList>();
            dilogueList.SetDialogue(newDialogue);
            HasBeenUsed = true;
            UpdateInteraction();
        }

        public override void _Ready()
        {
            UpdateInteraction();
        }
    }
}
