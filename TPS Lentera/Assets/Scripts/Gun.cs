using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour, Weapon
{
    private Shoot _shoot;
    [SerializeField]
    private Transform _gunPointTransform;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private int _damage;

    public int damage { get; private set; }


    private void Awake()
    {
        _shoot = GetComponent<Shoot>();
    }

    public void Attack(int damage)
    {
        damage = _damage;
        _shoot.ShootObj(_bulletPrefab, _gunPointTransform, damage);
    }
    public void Setup(Vector3 originShoot, Vector3 targetShoot)
    {
        _shoot.SetTarget(originShoot, targetShoot);
    }
}
