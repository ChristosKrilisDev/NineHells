using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]private float _moveSpeed = 5f;
    [SerializeField]private float _jumpForce = 5f;
    private bool _isJumping;
    private Rigidbody  _rb;

    private const string GROUND_TAG = "Ground"; 

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _isJumping = false;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var moveX = Input.GetAxis("Horizontal");
        var movement = new Vector3(moveX * _moveSpeed, _rb.velocity.y, 0f);
        _rb.velocity = movement;
    }

    private void Jump()
    {
        if (!Input.GetButtonDown("Jump") || _isJumping) return;
        
        _rb.AddForce(new Vector3(0f, _jumpForce, 0f), ForceMode.Impulse);
        _isJumping = true;
    } 
    
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isJumping = false;
        }
    }
}
