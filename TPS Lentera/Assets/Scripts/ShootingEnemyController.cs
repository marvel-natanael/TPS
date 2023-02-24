using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyController : EnemyController
{
    private void Awake()
    {
        InvokeRepeating("DoAttack", 3.0f, 1.5f);
        Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void DoAttack()
    {
        base.DoAttack(transform.position, transform.forward);
    }
}
