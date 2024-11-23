using Commons.Managers;
using FishingMiniGame;
using Godot;
using System;

namespace InteractSystem.Interactablos
{
    /// <summary>
    /// This first remove the player from the current scene by making it a child of the root.
    /// Then it changes scene
    /// </summary>
    public partial class TriggerChangeScene : Node3D, IInteractable
    {
        [Export]
        public string path { get; set; }
        public InteractableArea Area { get; set; }
        public Action OnInteraction { get; set; }

        public override void _Ready()
        {
            FishingManager.Instance.OnPlayerStopFishing += EnableSelf;
        }

        private void EnableSelf()
        {
            GetParent().GetParent().ProcessMode = ProcessModeEnum.Inherit;
        }
        public void Interaction()
        {
            GameManager.Instance.RemovePlayerFromScene();
            GetTree().ChangeSceneToFile(path);
        }

        public override void _ExitTree()
        {
            FishingManager.Instance.OnPlayerStopFishing -= EnableSelf;

        }
    }
}
