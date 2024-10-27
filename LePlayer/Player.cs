using Godot;
using System;
using Commons.Components;
using Commons.Managers;
using Commons.FSM;

namespace LePlayer
{

    public partial class Player : CharacterBody3D
    {
        [Export]
        private VelocityComponent3D velocityComp;

        [Export]
        public float Sens = 0.02f;

        [Export] public Node3D Head { get; private set; }
        [Export] public Camera3D Camera { get; private set; }
        [Export] public FiniteStateMachine FSM { get; private set; }

        private bool jumping;

        private Vector3 vel;

        private Vector2 Inputdir;
        private Vector3 dir;

        public bool disableMovement;
        public void GetInput()
        {
            jumping = Input.IsActionJustPressed("Jump");
            Inputdir = Input.GetVector("Left", "Right", "Foward", "Back");
            dir = (Head.GlobalTransform.Basis * new Vector3(Inputdir.X, 0, Inputdir.Y)).Normalized();
        }
        
        public void Jump()
        {
            vel.Y = velocityComp.JumpForce;

        }
        public void Movement(float delta)
        {
            if (Input.IsActionPressed("Sprint"))
            {
                velocityComp.SetSpeed(velocityComp.SprintSpeed);
            }
            else
            {
                velocityComp.SetSpeed(velocityComp.BaseSpeed);
            }
            if (IsOnFloor())
            {

                if (dir != Vector3.Zero)
                {
                    vel.X = dir.X * velocityComp.Speed;
                    vel.Z = dir.Z * velocityComp.Speed;
                }
                else
                {
                    vel.X = Mathf.Lerp(Velocity.X, dir.X * velocityComp.Speed, delta * 7f);
                    vel.Z = Mathf.Lerp(Velocity.Z, dir.Z * velocityComp.Speed, delta * 7f);
                }
            }
            else
            {
                vel.X = Mathf.Lerp(Velocity.X, dir.X * velocityComp.Speed, delta * 3f);
                vel.Z = Mathf.Lerp(Velocity.Z, dir.Z * velocityComp.Speed, delta * 3f);
            }
        }
        public override void _Ready()
        {
            CursorManager.Instance.CaptureCursor();//change this later to be on a another script
        }

        public void PlayerMouseMovement(InputEvent @event)
        {
            if (disableMovement) return;
            if (@event is InputEventMouseMotion mouse)
            {
                Vector3 camRot = new Vector3();
                Head.RotateY(-mouse.Relative.X * Sens);
                Camera.RotateX(-mouse.Relative.Y * Sens);
                camRot.X = Mathf.Clamp(Camera.Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(80));
                Camera.Rotation = camRot;
            }
        }
    
        public void ControlPlayer(double delta)
        {
            if (disableMovement) return;
            vel = Velocity;
            vel.Y = velocityComp.AddGravity((float)delta);
            GetInput();
            if (jumping && IsOnFloor())
            {
                Jump();
            }
            Movement((float)delta);
            Velocity = vel;
            velocityComp.ActivateMovement();
        }
    }
}
