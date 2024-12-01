using Godot;
using System;
using Commons.FSM;
using FishingMiniGame;

namespace LePlayer.States
{
    /// <summary>
    /// Player fishing related controls
    /// </summary>
    public partial class FishingState : State
    {
        private Player LePlayer;

        public override void Readys()
        {
            LePlayer = GetParent().GetParent<Player>();
        }

        public override void HandleInput(InputEvent @event)
        {
            LePlayer.PlayerMouseMovement(@event);
        }
        public override void Exit()
        {
            FishingManager.Instance.ExitFishingMode();
            LePlayer.FishingRod.Visible = false;
        }

        public override void FixUpdate(float delta)
        {
            //Player equips the fishing pole
            if (Input.IsActionJustPressed("FishingButton"))
            {
                if (FishingManager.Instance.IsInFishingMode)
                {
                    FishingManager.Instance.ExitFishingMode();
                    LePlayer.FishingRod.Visible = false;

                }
                else
                {
                    FishingManager.Instance.EnterFishingMode();
                    LePlayer.FishingRod.Visible = true;

                }
                GD.Print("Is on fishing mode?" + FishingManager.Instance.IsInFishingMode);
            }
            //player starts fishing if has fishing pool equiped
            if(Input.IsActionJustPressed("InteractButton") && FishingManager.Instance.IsInFishingMode)
            {
                FishingManager.Instance.SelectFishingAction();
            }
        }
    }
}
