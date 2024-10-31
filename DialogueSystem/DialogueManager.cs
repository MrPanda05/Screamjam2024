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
            if (_currentPage > _currentDialogue.Pages.Count - 1) return;
            GD.Print($"Char named {_currentKey} said :{_currentDialogue.Pages[_currentPage][_currentKey]}");
        }
        public void DebugPrint()
        {
            GD.Print("==================");
            GD.Print($"Current page: {_currentPage}");
            GD.Print($"Page count: {_currentDialogue.Pages.Count - 1}");
            _keyList.ForEach(Item => GD.Print($"Key list page: {Item}"));
            GD.Print($"Current key: {_currentKey}");
            GD.Print($"Current key index: {_keyIndex}");
            GD.Print($"Current key count: {_keyList.Count}");
            GD.Print("==================");

        }
        //key count = 1 => keyindex == 0
        //key count = 2 => keyindex == 0 ou 1
        //O npc fala e nao tem resposta do player no mesmo dicionario
        //

        private void UpdateKeys()
        {
            if (_currentPage > _currentDialogue.Pages.Count - 1) return;
            _keyIndex = 0;
            Godot.Collections.Dictionary<string, string> item = _currentDialogue.Pages[_currentPage];
            _keyList = item.Keys.ToList();
            _currentKey = _keyList[_keyIndex];
        }
        private void ChangePageOrDialogue()
        {
            if (_currentPage > _currentDialogue.Pages.Count - 1) return;
            _keyIndex++;
            if ((_keyList.Count == 1 && _keyIndex != 0) || (_keyList.Count == 2 && _keyIndex > 1))
            {
                _currentPage++;
                UpdateKeys();
                GD.Print("cHANGE PAGE");
            }
            else
            {
                _currentKey = _keyList[_keyIndex];
                GD.Print("Next index");

            }
        }
        private void NextDialogue()
        {
            ChangePageOrDialogue();
            DebugPrint();
        }
        
        public void StartDialogue(DialogueResource dialogue)
        {
            _currentDialogue = dialogue;
            _currentPage = 0;
            _keyIndex = 0;
            Godot.Collections.Dictionary<string, string> item = _currentDialogue.Pages[_currentPage];
            _keyList = item.Keys.ToList();
            _currentKey = _keyList[_keyIndex];
            DebugPrint();
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
                NextDialogue();
                PrintCurrentDialogue();
            }
        }
    }
}
