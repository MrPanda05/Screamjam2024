using Godot;
using InteractSystem;
using System;

namespace DialogueSystem
{
    /// <summary>
    /// Trigger a simple one message inner monologue
    /// used for giving player hints or simple story related
    /// </summary>
    public partial class StartInnerMonologue : Node3D, IInteractable
    {
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }
        [Export]
        public string myDialogue;

        public override void _Ready()
        {
            Area = GetParent<InteractableArea>();

        }
        public void Interaction()
        {
            DialogueManager.Instance.StartInnerMonologue(myDialogue);
        }
    }
}
