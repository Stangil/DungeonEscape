﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    private bool _grounded = false;
    [SerializeField]
    private float _jumpforce = 250.0f;  
    [SerializeField]
    private float groundedRay = 1.0f;
    [SerializeField]
    private float _speed = 100.0f;
    
    private int health = 4;
    private PlayerAnimation _playerAnimation;
    
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _sword_ArcSpriteRenderer;
    public int Health { get; set; }

    void Start()
    {
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _sword_ArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigid = GetComponent<Rigidbody2D>();
        Health = health;
    }

    void Update()
    {
        Movement();
        if(CrossPlatformInputManager.GetButtonDown("A_Button") && _grounded)
        {
            _playerAnimation.Attacking();
        }
    }

    private void Movement()
    {
        float move = CrossPlatformInputManager.GetAxis("Horizontal");// Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        //Flips sprite when changing direction
        FlipSprite(move);
        Jump();
        //Horizontal movement
        _rigid.velocity = new Vector2(move * _speed * Time.deltaTime, _rigid.velocity.y);
        //send movement speed to playerAnimation
        _playerAnimation.Move(move);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce * Time.deltaTime);

            StartCoroutine(ResetJumpRoutine());
            //Tell animator jump
            _playerAnimation.Jumping(true);
        }
    }

    private void FlipSprite(float move)
    {
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, groundedRay, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        if (hitInfo.collider != null && _resetJump == false)
        {
            _playerAnimation.Jumping(false);
            return true;
        }
        return false;
    }
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }
        Debug.Log("Player damaged");
        Health--;
        UIManager.UIinstance.UpdateLives(Health);



        if (Health < 1)
        {
            _playerAnimation.Death();
        }

    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.UIinstance.UpdateGemCount(diamonds);
    }
}
