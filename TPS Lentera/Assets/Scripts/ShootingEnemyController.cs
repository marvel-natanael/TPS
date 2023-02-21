using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyController : EnemyController
{
    private Gun _gun;

    private void Awake()
    {
        _gun = GetComponentInChildren<Gun>();
        InvokeRepeating("Attack", 3.0f, 1.5f);
        Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        _gun.ShootGun(transform.position, transform.forward);
    }
}
