using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField]
    private Vector3 _target;

    protected virtual void FixedUpdate()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (_target != null)
        {
            Vector3 targetPos = transform.TransformDirection(_target - transform.position);
            MoveObj(targetPos);
            RotateObj(_target);
            Die();
        }
    }
}
