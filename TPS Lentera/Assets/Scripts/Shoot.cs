using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Vector3 _originShoot { get; set; }
    public Vector3 _targetShoot { get; set; }
    public void SetTarget(Vector3 originShoot, Vector3 targetShoot) 
    {
        _originShoot = originShoot;
        _targetShoot = targetShoot;
    }
    public void ShootObj(GameObject bulletPrefab, Transform gunpointTransform, int damage)
    {
        RaycastHit hit;
        GameObject bulletObj = Instantiate(bulletPrefab, gunpointTransform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (Physics.Raycast(_originShoot, _targetShoot, out hit, Mathf.Infinity))
        {
            bullet.damage = damage;
            bullet.target = hit.point;
            bullet.Hit = true;
        }
        else
        {
            bullet.target = _originShoot + _targetShoot * 25f;
            bullet.Hit = false;
        }
    }
}
