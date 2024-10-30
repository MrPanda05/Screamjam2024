using FishingMiniGame.Fishes;
using Godot;
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
        public DialogueResource() 
        {
            
        }
    }
}
