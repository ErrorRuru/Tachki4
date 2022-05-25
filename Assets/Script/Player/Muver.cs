using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muver : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;

    private Vector3 _muvmentVector
    {
        get
        {
            var horisontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horisontal, 0.0f, vertical);
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MuveLogic();
    }

    private void MuveLogic()
    {
        _rb.AddForce(_muvmentVector * _speed, ForceMode.Impulse);
    }
}
