using Commons.FiniteStateMachine;
using Game.Player.States;
using Godot;
using System;

namespace Game.Player
{
    public partial class LePlayer : CharacterBody3D
    {
        [Export]
        public float Sensitivity { get; private set; } = 0.02f;
        [Export]
        public Head HeadNode { get; private set; }
        [Export]
        public FSM FiniteStateMachine { get; private set; }

        //Bools for states
        private bool _permitMovement;
        private bool _isMouseAllowed;
        //Inputs
        private bool _isJumping;
        private bool _isSprinting;
        private Vector2 _inputVector;
        //Propreties
        private Vector3 _vel;
        private Vector3 _direction;
        [Export]
        private float _gravity = 980f;
        [Export]
        private float _jumpForce = 500f;
        [Export]
        private float _speed = 300f;


        public void GetInput()
        {
            _inputVector = Input.GetVector("Left", "Right", "Foward", "Back");
            _isJumping = Input.IsActionJustPressed("Jump");
            _isSprinting = Input.IsActionPressed("Sprint");
            _direction = (HeadNode.GlobalTransform.Basis * new Vector3(_inputVector.X, 0, _inputVector.Y)).Normalized();
        }

        public void CameraMovement(InputEvent @event)
        {
            if (!_isMouseAllowed) return;
            if (@event is InputEventMouseMotion mouse)
            {
                Vector3 camRot = new Vector3();
                HeadNode.RotateY(-mouse.Relative.X * Sensitivity);
                HeadNode.PlayerCamera.RotateX(-mouse.Relative.Y * Sensitivity);
                camRot.X = Mathf.Clamp(HeadNode.PlayerCamera.Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(80));
                HeadNode.PlayerCamera.Rotation = camRot;
            }
        }

        public void AllowMovement(bool value)
        {
            _permitMovement = value;
        }
        public void AllowMouseMovement(bool value)
        {
            _isMouseAllowed = value;
        }   

        private void Movement(float delta)
        {
            if (IsOnFloor())
            {
                if (_direction != Vector3.Zero)
                {
                    _vel.X = _direction.X * _speed;
                    _vel.Z = _direction.Z * _speed;
                }
                else
                {
                    _vel.X = Mathf.Lerp(Velocity.X, _direction.X * _speed, delta * 7f);
                    _vel.Z = Mathf.Lerp(Velocity.Z, _direction.Z * _speed, delta * 7f);
                }
            }
            else
            {
                _vel.X = Mathf.Lerp(Velocity.X, _direction.X * _speed, delta * 3f);
                _vel.Z = Mathf.Lerp(Velocity.Z, _direction.Z * _speed, delta * 3f);
            }
        }
        public void Jump()
        {
            _vel.Y = _jumpForce;
        }
        public void Move(float delta)
        {
            if(!_permitMovement) return;
            _vel = Velocity;
            if (!IsOnFloor())
            {
                _vel.Y -= _gravity * delta;
            }
            else
            {
                _vel.Y = 0;
            }
            if(_isJumping && IsOnFloor())
            {
                Jump();
            }
            Movement((float)delta);
            Velocity = _vel;
            MoveAndSlide();
        }
    }
}
