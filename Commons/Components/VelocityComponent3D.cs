using Godot;
using System;


namespace Commons.Components
{
    public partial class VelocityComponent3D : Node
    {
        [ExportGroup("Propreties")]
        [Export] public float Speed { get; private set; } = 800f;
        [Export] public float MaxSpeed { get; private set; } = 1600f;
        [Export] public float Aceleration { get; private set; } = 1f;
        [Export] public float Friction { get; private set; } = 0.25f;
        [Export] public float JumpForce { get; private set; } = 2000f;
        [Export] public float GravityForce { get; private set; } = 980f;
        [Export] public float TerminalVelocity { get; private set; } = 1600;
        [Export] public bool HasGravity { get; private set; } = true;
        [Export] public float SprintSpeed { get; private set; } = 8f;
        [Export] public float BaseSpeed { get; private set; } = 5f;



        [ExportSubgroup("Individual")]
        [Export] private CharacterBody3D myIndividual;

        private Vector3 vel;

        public void SetSprintSpeed(float newSprintSpeed)
        {
            SprintSpeed = newSprintSpeed;
        }
        public void SetBaseSpeed(float newSpeed)
        {
            BaseSpeed = newSpeed;
        }
        public bool ActivateMovement()
        {
            return myIndividual.MoveAndSlide();
        }
        public Vector3 GetVelocity()
        {
            return vel;
        }

        public void SetSpeed(float newSpeed)
        {
            Speed = Mathf.Abs(newSpeed);
        }

        public void AddSpeed(float newSpeed)
        {
            Speed += newSpeed;
            Mathf.Round(Speed);
        }

        public void SetMaxSpeed(float newMaxSpeed)
        {
            if (MaxSpeed <= 0)
            {
                GD.PushWarning("Value less than zero or iqual zero, May cause unintended behaviour");
            }
            MaxSpeed = newMaxSpeed;
            GD.Print($"Set speed to {newMaxSpeed}");
        }
        public void SetAcelleration(float newAce)
        {
            Aceleration = newAce;
            GD.Print($"Set aceleration to {newAce}");
        }

        public void SetFriction(float newFriction)
        {
            Friction = newFriction;
            GD.Print($"Set friction to {newFriction}");
        }

        public void SetJumpForce(float newJumpForce)
        {
            JumpForce = newJumpForce;
            GD.Print($"Set jump force to {newJumpForce}");
        }

        public void SetGravityForce(float newGravity)
        {
            if (newGravity <= 0)
            {
                GD.PushWarning("Gravity setting to negative or iqual zero may cause uninteded behaviour");
            }
            GravityForce = newGravity;
            GD.Print($"Set gravity to {newGravity}");
        }

        public void SetTerminalVelocity(float newTerminalVelocity)
        {
            TerminalVelocity = Mathf.Abs(newTerminalVelocity);
            GD.Print($"Set terminal velocity to {newTerminalVelocity}");
        }

        public void SwitchGravity()
        {
            HasGravity = !HasGravity;
            GD.Print($"Gravity is now {HasGravity}");
        }

        public void SetGravity(bool hasGravityValue)
        {
            HasGravity = hasGravityValue;
        }
        public float AddGravity(float delta)
        {
            if (!HasGravity) return 0;
            if (myIndividual == null) return 0;
            if (myIndividual.IsOnFloor()) return 0;
            vel = myIndividual.Velocity;
            vel.Y -= GravityForce * delta;
            vel.Y = Mathf.Clamp(vel.Y, -TerminalVelocity, TerminalVelocity);
            return vel.Y;
        }
    }
}
