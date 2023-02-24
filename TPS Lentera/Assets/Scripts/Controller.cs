using UnityEngine;

public class Controller : MonoBehaviour
{
    protected CharacterController _controller;
    protected Vector3 _playerVelocity;

    [SerializeField]
    protected float _playerSpeed = 2.0f;
    [SerializeField]
    protected float _jumpHeight = 1.0f;
    [SerializeField]
    protected float _gravityValue = -9.81f;
    [SerializeField]
    protected float _rotationSpeed = 2.0f;
    [SerializeField]
    protected int Health;
    [SerializeField]
    protected int Damage;
    private Move _move;
    private Rotate _rotate;
    private Attack _attack;

    public Transform _cameraTransForm;
    public int GetHealth()
    {
        return Health;
    }

    protected void Init()
    {
        _move = GetComponent<Move>();
        _rotate = GetComponent<Rotate>();
        _attack = GetComponent<Attack>();
    }

    public virtual void DoAttack(Vector3 origin, Vector3 target)
    {
        _attack.DoAttack(origin, target);
    }   
    public virtual void DoAttack() { }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public virtual void Die()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void RotateObj(float targetAngle, float rotationSpeed)
    {
        _rotate.RotateObj(targetAngle, rotationSpeed);
    }
    public virtual void RotateObj(Vector3 target)
    {
        _rotate.RotateObj(target);
    }

    public virtual void MoveObj(Vector3 movePos)
    {
        _move.MoveObj(movePos);
    }

    public virtual void MoveObj() { }
}
