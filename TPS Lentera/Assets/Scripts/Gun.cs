using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform _gunPointTransform;

    [SerializeField]
    private GameObject _bulletPrefab;

    private void Awake()
    {
        _gunPointTransform = gameObject.transform.GetChild(0).transform;
    }

    private void Shoot(Vector3 originShoot, Vector3 targetShoot, int damage)
    {
        RaycastHit hit;
        GameObject bulletObj = GameObject.Instantiate(_bulletPrefab, _gunPointTransform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (Physics.Raycast(originShoot, targetShoot, out hit, Mathf.Infinity))
        {
            bullet.damage = damage;
            bullet.target = hit.point;
            bullet.hit = true;
        }
        else
        {
            bullet.target = originShoot + targetShoot * 25f;
            bullet.hit = false;
        }
    }

    public void ShootGun(Vector3 originShoot, Vector3 targetShoot)
    {
        int damage = GetComponentInParent<Controller>().GetDamage();
        Shoot(originShoot, targetShoot, damage);
    }
}
