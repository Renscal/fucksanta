using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator ak_anim;
    public CharacterController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ak_anim.SetBool("isWalking", controller.velocity != Vector3.zero);   
        
    }

    public void DoShootAnim()
    {
        ak_anim.SetTrigger("doShoot");
    }
}
