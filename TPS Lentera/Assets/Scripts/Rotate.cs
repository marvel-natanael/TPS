using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    protected float _rotateSpeed = 2.0f;
    protected CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    public void RotateObj(float targetAngle, float rotationSpeed)
    {
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    public void RotateObj(Vector3 target)
    {
        Vector3 angle = (target - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _rotateSpeed);
    }
}