using Godot;
using System;

namespace Commons.DialogueSystem
{
    [GlobalClass]
    public partial class Dialogue : Resource
    {
        [Export]
        public string Author { get; set; }
        [Export]
        public string Text { get; set; }
    }
}
