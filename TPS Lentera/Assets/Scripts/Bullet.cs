using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _destroyDelay = 3f;
    [SerializeField]
    private float _speed = 30f;

    public int damage { get; set; }

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, _destroyDelay);
    }

    void Update()
    {
        Move(target);
    }

    private void Move(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Controller target = collision.gameObject.GetComponent<Controller>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}
