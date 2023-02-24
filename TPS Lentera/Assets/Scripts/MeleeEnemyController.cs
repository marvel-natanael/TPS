using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : EnemyController
{
    private void Awake()
    {
        Init();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Controller target = hit.gameObject.GetComponent<Controller>();
        if (target != null && hit.gameObject.tag == "Player")
        {
            target.TakeDamage(Damage);
        }
    }
}
