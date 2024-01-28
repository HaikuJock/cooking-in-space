using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 2.0f;

    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    [Tooltip("Acceleration and deceleration")]
    public float SpeedChangeRate = 10.0f;

    public float moveSpeed = 2.0f;
    private float _speed;
    private PlayerInput _playerInput;
    private StarterAssetsInputs _input;
    private Rigidbody _rigidBody;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity = 0.0f;
    private bool _hasAnimator;
    private Animator _animator;
    private int _animIDSpeed;
    private int _animIDMotionSpeed;

    private GameObject _mainCamera;

    private bool IsCurrentDeviceMouse
    {
        get
        {
            return _playerInput.currentControlScheme == "KeyboardMouse";
        }
    }

    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

   private void Start()
   {
        _hasAnimator = TryGetComponent(out _animator);
        _input = GetComponent<StarterAssetsInputs>();
        _rigidBody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        AssignAnimationIDs();
   }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    void Update()
    {
        Move();
    }

    public void SlowForTether(Vector3 vec)
    {
    }

    public void SpeedUpForTether(Vector3 vec)
    {
    }

    private void Move()
    {
        moveSpeed = MoveSpeed;

        // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is no input, set the target speed to 0
        if (_input.move == Vector2.zero) moveSpeed = 0.0f;
        
        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_rigidBody.velocity.x, 0.0f, _rigidBody.velocity.z).magnitude;
        
        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;
        
        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < moveSpeed - speedOffset ||
            currentHorizontalSpeed > moveSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, moveSpeed * inputMagnitude,
                Time.deltaTime * SpeedChangeRate);
        
            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = moveSpeed;
        }
        
        _animationBlend = Mathf.Lerp(_animationBlend, moveSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;
        
        // normalise input direction
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;
        
        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_input.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);
        
            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
        
        
        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        
        // move the player
        // _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
        //                     new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        
        // update animator if using character
        if (_hasAnimator)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        }
    }
}
