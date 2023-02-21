using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField]
    private Vector3 target;

    protected virtual void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (target != null)
        {
            Move();
            Rotate();
            Die();
        }
    }

    protected override void Move()
    {
        Vector3 targetPos = transform.TransformDirection(target - transform.position);
        base.Move(targetPos);
    }

    protected override void Rotate()
    {
        Vector3 targetAngle = (target - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
    }
}
