using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    private bool _groundedPlayer;
    private PlayerInput _playerInput;
    private InputAction _jumpAction;
    private InputAction _moveAction;
    private InputAction _shootAction;


    public delegate void PlayerDied();
    public static event PlayerDied onPlayerDied;

    private void Awake()
    {
        Init();
        _cameraTransForm = Camera.main.transform;
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Movement"];
        _jumpAction = _playerInput.actions["Jump"];
        _shootAction = _playerInput.actions["Shoot"];
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _shootAction.performed += _ => DoAttack();
    }

    private void OnDisable()
    {
        _shootAction.performed -= _ => DoAttack();
    }

    void FixedUpdate()
    {
        Jump();
        MoveObj();
        RotateObj(_cameraTransForm.eulerAngles.y, _rotationSpeed);
        Die();
    }

    public override void Die()
    {
        if (Health <= 0)
        {
            onPlayerDied?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Jump()
    {
        if (_jumpAction.triggered && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }
    }

    public override void MoveObj()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(input.x, 0, input.y);

        moveVector = moveVector.x * _cameraTransForm.right.normalized + moveVector.z * _cameraTransForm.forward.normalized;
        moveVector.y = 0f;

        base.MoveObj(moveVector);
    }

    public override void DoAttack()
    {
        base.DoAttack(_cameraTransForm.position, _cameraTransForm.forward);
    }
}
