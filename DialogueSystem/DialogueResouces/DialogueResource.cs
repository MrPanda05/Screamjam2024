using FishingMiniGame.Fishes;
using Godot;
using InteractSystem;
using System;
using System.Collections.Generic;

namespace DialogueSystem.DiaResource
{
    /// <summary>
    /// Resouce that holds the dialogue
    /// </summary>
    [GlobalClass]
    public partial class DialogueResource : Resource
    {
        [Export]
        public Godot.Collections.Array<Godot.Collections.Dictionary<string, string>> Pages { get; set; }//This is absolutly retarded

        public int MyId { get; private set; }

        public Action<int> OnDialogueEnded;

        public DialogueResource() 
        {
            var rng = new RandomNumberGenerator();
            MyId = (int)rng.Randi();
        }

        public void OnDialogueEnd()
        {
            OnDialogueEnded?.Invoke(MyId);
        }
    }
}
