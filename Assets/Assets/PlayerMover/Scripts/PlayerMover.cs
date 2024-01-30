using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private const string CURRENT_LEVEL_MOVE_SPEED = "CurrentLevelMoveSpeed";

    [SerializeField] private float _currentMoveSpeed;
    [SerializeField] private float _rotationFactorPerFrame = 1;

    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private bool _isMovementPressed;
    private int _currentLevel = 1;
    private int _maxLevel = 6;

    public int CurrentLevel => _currentLevel;
    public int MaxLevel => _maxLevel;
    public float MoveSpeed => _currentMoveSpeed;
    public Action<bool> MovementChanged;
    public Action LevelIncreased;
    public Action MaxLevelReached;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();

        _playerInput.CharacterControl.Move.started += OnMovementInput;
        _playerInput.CharacterControl.Move.canceled += OnMovementInput;
        _playerInput.CharacterControl.Move.performed += OnMovementInput;

        if (PlayerPrefs.HasKey(CURRENT_LEVEL_MOVE_SPEED))
        {
            _currentLevel = PlayerPrefs.GetInt(CURRENT_LEVEL_MOVE_SPEED);
            _currentMoveSpeed += _currentLevel;
            if(_currentLevel >= _maxLevel)
            {
                MaxLevelReached?.Invoke();
            }
            else
            {
                LevelIncreased?.Invoke();
            }
        }
    }


    private void OnEnable()
    {
        _playerInput.CharacterControl.Enable();
    }

    private void OnDisable()
    {
        _playerInput.CharacterControl.Disable();
    }

    private void Update()
    {
        HandleRotation();
        _characterController.Move(_currentMovement * _currentMoveSpeed * Time.deltaTime);
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x;
        _currentMovement.z = _currentMovementInput.y;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
        MovementChanged?.Invoke(_isMovementPressed);
    }

    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    public void IncreaseMoveSpeed()
    {
        _currentLevel++;
        _currentMoveSpeed++;
        PlayerPrefs.SetInt(CURRENT_LEVEL_MOVE_SPEED, _currentLevel);
        if (_currentLevel >= _maxLevel)
        {
            MaxLevelReached?.Invoke();
        }
        else
        {
            LevelIncreased?.Invoke();
        }
    }
}
