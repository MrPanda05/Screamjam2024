using DialogueSystem.DiaResource;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using Ui;

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

        public DialogueState CurrentState { get; private set; }

        private int _currentPage;
        private List<string> _keyList;
        private string _currentKey;
        private DialogueResource _currentDialogue;
        private int _keyIndex;
        private Timer _timerMonologue;

        private GameUi _gameUi;
        private DialogueBox _dialogueBox;

        public static Action<int> OnDialogueChanged;
        public static Action<int> OnDialogueStoped;


        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            _timerMonologue = GetChild<Timer>(0);
        }

        #region DebugDialogue
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
            GD.Print($"Page count: {_currentDialogue?.Pages.Count - 1}");
            _keyList?.ForEach(Item => GD.Print($"Key list page: {Item}"));
            GD.Print($"Current key: {_currentKey}");
            GD.Print($"Current key index: {_keyIndex}");
            GD.Print($"Current key count: {_keyList?.Count}");
            GD.Print("==================");

        }
        #endregion

        #region NPC_DialogueSystem
        private void UpdateKeys()
        {
            if (_currentPage > _currentDialogue.Pages.Count - 1) return;
            _keyIndex = 0;
            Godot.Collections.Dictionary<string, string> item = _currentDialogue.Pages[_currentPage];
            _keyList = item.Keys.ToList();
            _currentKey = _keyList[_keyIndex];
        }
        private void ChangePage()
        {
            _currentPage++;
            UpdateKeys();
            GD.Print("cHANGE PAGE");
        }
        private void ChangePageOrDialogue()
        {
            if (_currentPage == _currentDialogue.Pages.Count - 1)
            {
                CurrentState = DialogueState.FREE;
                StopDialogue();
                OnDialogueStoped?.Invoke(_currentDialogue.MyId);
                return;
            }
            _keyIndex++;
            if ((_keyList.Count == 1 && _keyIndex != 0) || (_keyList.Count == 2 && _keyIndex > 1))
            {
                ChangePage();
                OnDialogueChanged?.Invoke(_currentDialogue.MyId);
            }
            else
            {
                _currentKey = _keyList[_keyIndex];
                GD.Print("Next index");
                OnDialogueChanged?.Invoke(_currentDialogue.MyId);
            }
        }
        private void NextDialogue()
        {
            ChangePageOrDialogue();
            DebugPrint();
        }
        public void ShowCurrentDialogue()
        {
            if (CurrentState != DialogueState.USING) return;
            if (_currentPage > _currentDialogue.Pages.Count - 1) return;
            _gameUi.SetVisibilityDialogueBox(true);
            _dialogueBox.UpdateDialogue(_currentDialogue.Pages[_currentPage][_currentKey], _currentKey);
        }
        public void StopDialogue()
        {
            GD.Print("End");
            _gameUi.SetVisibilityDialogueBox(false);
            _dialogueBox.UpdateDialogue(string.Empty, string.Empty);
            _currentDialogue = null;
            _currentPage = 0;
            _keyIndex = 0;
            _keyList = null;
            _currentKey = string.Empty;

        }

        public void StartDialogue(DialogueResource dialogue)
        {
            if (CurrentState == DialogueState.OTHER) return;
            if(_dialogueBox == null)
            {
                _gameUi = GetTree().GetFirstNodeInGroup("GameUI") as GameUi;
                _dialogueBox = _gameUi.DialogueBoxNode;
            }
            
            //Add check to see if is already in use
            //Override the dialogue
            CurrentState = DialogueState.USING;
            _currentDialogue = dialogue;
            GD.Print(_currentDialogue.MyId);
            _currentPage = 0;
            _keyIndex = 0;
            Godot.Collections.Dictionary<string, string> item = _currentDialogue.Pages[_currentPage];
            _keyList = item.Keys.ToList();
            _currentKey = _keyList[_keyIndex];
            //DebugPrint();
            //PrintCurrentDialogue();
            ShowCurrentDialogue();
        }
        public void ForceStopCurrentDialogue()
        {
            //stops current dialogue
            CurrentState = DialogueState.FREE;
            StopDialogue();
        }
        #endregion

        #region InnerMonologue
        public void StartInnerMonologue(string text)
        {
            if(CurrentState == DialogueState.USING) return;
            if (_dialogueBox == null)
            {
                _gameUi = GetTree().GetFirstNodeInGroup("GameUI") as GameUi;
                _dialogueBox = _gameUi.DialogueBoxNode;
            }
            _gameUi.SetVisibilityDialogueBox(true);
            _dialogueBox.UpdateMonologue(text);
            _timerMonologue.Start();

        }

        public void OnInnerMonologueTimerTimeout()
        {
            _gameUi.SetVisibilityDialogueBox(false);
            _dialogueBox.UpdateDialogue(string.Empty, string.Empty);
        }
        #endregion

        public override void _UnhandledInput(InputEvent @event)
        {
            if (CurrentState != DialogueState.USING) return;
            if (@event is not InputEventKey eventKey) return;
            if (eventKey.Pressed && !eventKey.IsEcho() && eventKey.Keycode == Key.P)
            {
                NextDialogue();
                //PrintCurrentDialogue();
                ShowCurrentDialogue();
            }
        }
    }
}
