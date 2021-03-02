using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Collider2D _ground;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Start()
    { 
        _rigidbody = GetComponent<Rigidbody2D>();

        _collider = GetComponent<Collider2D>();

        ResetPlayer();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _collider.IsTouching(_ground))
        {
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }
    }

    private void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}
