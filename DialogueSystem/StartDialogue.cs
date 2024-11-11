using DialogueSystem.DiaResource;
using Godot;
using InteractSystem;
using System;

namespace DialogueSystem
{
    /// <summary>
    /// Trigger a NPC dialogue
    /// </summary>
    public partial class StartDialogue : Node3D, IInteractable
    {
        [Export]
        public DialogueResource MyDialogue { get; private set; }
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        public override void _Ready()
        {
            Area = GetParent<InteractableArea>();
            
        }
        public void Interaction()
        {
            DialogueManager.Instance.StartDialogue(MyDialogue);
        }
    }
}
