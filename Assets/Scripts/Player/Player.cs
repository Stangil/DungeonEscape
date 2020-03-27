using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private bool _resetJump = false;
    private bool _grounded = false;
    [SerializeField]
    private float _jumpforce = 250.0f;  
    [SerializeField]
    private float groundedRay = 1.0f;
    [SerializeField]
    private float _speed = 100.0f;
      
    private PlayerAnimation _playerAnimation;
    
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _sword_ArcSpriteRenderer;
    void Start()
    {
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _sword_ArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        if(Input.GetMouseButtonDown(0) && _grounded)
        {
            _playerAnimation.Attacking();
        }
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
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
}
