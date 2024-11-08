using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;
    public Rigidbody2D _rb;
    private Animator _animator;
    // public InputActionReference move;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LAST_HORIZONTAL = "LastHorizontal";
    private const string LAST_VERTICAL = "LastVertical";

    private Vector2 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.velocity = _movement * _moveSpeed;

        _animator.SetFloat(HORIZONTAL, _movement.x);
        _animator.SetFloat(VERTICAL, _movement.y);

        if(_movement!= Vector2.zero)
        {
            _animator.SetFloat(LAST_HORIZONTAL, _movement.x);
            _animator.SetFloat(LAST_VERTICAL, _movement.y);
        }
    }

    // void FixedUpdate()
    // {
    //     //Movement
    //     rb.velocity = new Vector2(_movement.x * moveSpeed, _movement.y * moveSpeed);
    // }
}
