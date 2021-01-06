using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _topForce;
    [SerializeField] private Collider2D _ground;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _collider.IsTouching(_ground))
        {
            _rigidbody.AddForce(Vector2.up * _topForce, ForceMode2D.Force);
        }
    }
    public void ResetBird()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
