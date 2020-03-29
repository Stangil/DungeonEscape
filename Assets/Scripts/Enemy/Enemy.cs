using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;//waypoints
    [SerializeField]
    protected float waypointDistance = 0.1f;
    [SerializeField]
    protected float inCombatDistance = 2.0f;
    protected bool direction = false;
    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer sprite;

    protected bool isHit = false;
    [SerializeField]
    protected Player player;
    //var to store player
    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("InCombat") == false)
        {
            return;
        }
        Movement();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        currentTarget = pointA.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {
        InCombatLogic();

        if (Vector3.Distance(transform.position, pointA.position) < waypointDistance)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("Idle");
            direction = true;
        }
        else if (Vector3.Distance(transform.position, pointB.position) < waypointDistance)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");
            direction = false;
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        FlipSprite(direction);
    }

    private void InCombatLogic()
    {
        //distance to player
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        //direction to player
        Vector3 playerDirection = player.transform.localPosition - transform.localPosition;

        if (distance > inCombatDistance)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

        if (animator.GetBool("InCombat") == true)
        {
            if (playerDirection.x > 0)
            {
                direction = true;
            }
            else if (playerDirection.x < 0)
            {
                direction = false;
            }
        }
        else
        {
            if(currentTarget == pointA.position)
            {
                direction = false;
            }
            else
            {
                direction = true;
            }
        }
    }

    protected void FlipSprite(bool move)
    {
        if (move)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!move)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
