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
    protected bool direction = false;
    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer sprite;

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
        //sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Movement()
    {
        //Vector3.Distance(transform.position, pointA.position) < waypointDistance
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        FlipSprite(direction);
    }

    private void FlipSprite(bool move)
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
