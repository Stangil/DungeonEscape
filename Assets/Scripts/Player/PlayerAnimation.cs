using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator  
    private Animator _animator;
    private Animator _swordAnimator;

    void Start()
    {
        //assign handle to animator
        _animator = GetComponentInChildren<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }
    //Sending move value to animator to check for > 0
    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jumping(bool jumping)
    {
        Debug.Log("jumping: "+jumping);
        _animator.SetBool("Jumping", jumping);
    }

    public void Attacking()
    {
        _animator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
}
