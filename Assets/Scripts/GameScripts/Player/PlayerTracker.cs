using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _groundSpeed;
    private void Update()
    {
        transform.Translate(Vector3.right * _groundSpeed * Time.deltaTime);
    }
}
