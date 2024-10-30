using Commons.Managers;
using Godot;
using System;

namespace InteractSystem.Interactablos
{
    public partial class TriggerChangeScene : Node3D, IInteractable
    {
        [Export]
        public string path { get; set; }
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        public void Interaction()
        {
            GameManager.Instance.RemovePlayerFromScene();
            GetTree().ChangeSceneToFile(path);
        }
    }
}
