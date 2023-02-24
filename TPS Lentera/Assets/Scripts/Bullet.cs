using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _destroyDelay = 3f;
    private Move _move;
    public int damage { get; set; }
    public Vector3 target { get; set; }
    public bool Hit { get; set; }

    private void Awake()
    {
        _move = GetComponent<Move>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, _destroyDelay);
    }

    void Update()
    {
        MoveObj();
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

    public void MoveObj(Vector3 movePos)
    {
        _move.MoveObj(movePos);
        if (!Hit && Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    public void MoveObj()
    {
        MoveObj(target);
    }
}