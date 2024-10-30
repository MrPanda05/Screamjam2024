using DialogueSystem.DiaResource;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogueSystem
{
    public enum DialogueState
    {
        FREE,//The player is not in a dialogue
        USING,//The player is using the dialogue
        OTHER
    }
    public partial class DialogueManager : Node
    {
        public static DialogueManager Instance { get; private set; }

        private int _currentPage;
        private List<string> _keyList;
        private string _currentKey;
        private DialogueResource _currentDialogue;
        private int _keyIndex;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }
        
        //foreach (var item in MyDialogue.Pages)
         //{
         //    var keys = item.Keys;
         //    foreach (var Lekey in keys)
         //    {
         //        GD.Print($"{Lekey}: {item[Lekey]}");
         //    }
         //}
         //for (int i = 0; i < MyDialogue.Pages.Count; i++)
         //{
         //    Godot.Collections.Dictionary<string, string> item = MyDialogue.Pages[i];
         //    var keys = item.Keys;
         //    foreach (var Lekey in keys)
         //    {
         //        GD.Print($"{Lekey}: {item[Lekey]}");
         //    }
         //}

        public void PrintAllDialogue(DialogueResource dialogueResource)
        {
            foreach (var item in dialogueResource.Pages)
            {
                var keys = item.Keys;
                foreach (var Lekey in keys)
                {
                    GD.Print($"{Lekey}: {item[Lekey]}");
                }
            }
        }
        public void PrintCurrentDialogue()
        {
            if (_currentPage > _currentDialogue.Pages.Count) return;
            GD.Print($"Char named {_currentKey} said :{_currentDialogue.Pages[_currentPage][_currentKey]}");
        }
        private void UpdateKeys()
        {
            if (_currentPage > _currentDialogue.Pages.Count) return;
            Godot.Collections.Dictionary<string, string> item = _currentDialogue.Pages[_currentPage];
            _keyList = item.Keys.ToList();
            _currentKey = _keyList[_keyIndex];
        }
        public void NextDialogue()//Same page, used for when the player has a responde...
        {
            if (_currentPage > _currentDialogue.Pages.Count) return;
            _keyIndex++;
        }
        public void NextPage()
        {
            if (_currentPage > _currentDialogue.Pages.Count) return;
            _currentPage++;
            UpdateKeys();
        }

        public void StartDialogue(DialogueResource dialogue)
        {
            _currentDialogue = dialogue;
            _currentPage = 0;
            _keyIndex = 0;
            UpdateKeys();
            PrintCurrentDialogue();
        }
        /*
         Set current dialogue
         set current page
        Grab the list of they keys available
        Get the first key of the key of list
        print the first dialogue that being from the first page, the first key
        if press p
            increment the keyindex
        if(keyindex is greater than the numbers of keys)
            reset the key back to 0
            change next page and

         */
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is not InputEventKey eventKey) return;
            if (eventKey.Pressed && !eventKey.IsEcho() && eventKey.Keycode == Key.P)
            {
                _keyIndex++;
                if(_keyIndex < _keyList.Count)
                {
                    _keyIndex = 0;
                    NextPage();
                }
                PrintCurrentDialogue();
            }
        }
    }
}
