using UnityEngine;

public class Controller : MonoBehaviour
{
    protected CharacterController _controller;
    protected Vector3 _playerVelocity;
    protected Transform _cameraTransForm;

    [SerializeField]
    protected float _playerSpeed = 2.0f;
    [SerializeField]
    protected float _jumpHeight = 1.0f;
    [SerializeField]
    protected float _gravityValue = -9.81f;
    [SerializeField]
    protected float _rotationSpeed = 0.81f;
    [SerializeField]
    protected int Health;
    [SerializeField]
    protected int Damage;

    public int GetHealth()
    {
        return Health;
    }

    public int GetDamage()
    {
        return Damage;
    }

    protected void Init()
    {
        _controller = GetComponent<CharacterController>();
    }

    protected virtual void Move() { }

    protected virtual void Move(Vector3 movePos)
    {
        _controller.Move(movePos * Time.deltaTime * _playerSpeed);
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    protected virtual void Rotate()
    {
        float targetAngle = _cameraTransForm.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    protected virtual void Attack() { }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    protected virtual void Die()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
