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
        _shootAction.performed += _ => Attack();
    }

    private void OnDisable()
    {
        _shootAction.performed -= _ => Attack();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        Jump();
        Move();
        Rotate();
        Die();
    }

    protected override void Die()
    {
        if (Health <= 0)
        {
            onPlayerDied?.Invoke();
            Destroy(gameObject);
        }
    }

    private void CheckForGrounded()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
    }

    private void Jump()
    {
        if (_jumpAction.triggered && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }
    }

    protected override void Move()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        move = move.x * _cameraTransForm.right.normalized + move.z * _cameraTransForm.forward.normalized;
        move.y = 0f;

        base.Move(move);
    }

    protected override void Attack()
    {
        Gun gun = GetComponentInChildren<Gun>();
        gun.ShootGun(_cameraTransForm.position, _cameraTransForm.forward);
    }
}
