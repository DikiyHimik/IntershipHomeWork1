using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Collider2D _ground;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _horizontalSpeed;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private float _xSpeed;

    private void Start()
    { 
        _rigidbody = GetComponent<Rigidbody2D>();
        ResetPlayer();

        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        _xSpeed = _horizontalSpeed * Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(_xSpeed, 0, 0) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && _collider.IsTouching(_ground))
        {
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}
