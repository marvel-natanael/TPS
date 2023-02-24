using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    protected float _moveSpeed = 2.0f;
    [SerializeField]
    protected float _gravityValue = -9.81f;
    protected CharacterController _controller;
    protected Vector3 _velocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    public void MoveObj(Vector3 movePos)
    {
        if(_controller != null)
        {
            _controller.Move(movePos * Time.deltaTime * _moveSpeed);
            _velocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePos, _moveSpeed * Time.deltaTime);
        }
    }
}