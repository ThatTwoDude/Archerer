using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //running
        if (Input.GetAxisRaw("Vertical") !=0 && !Input.GetKey(KeyCode.LeftShift))
        { 
            //anim.SetTrigger("Attack");
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }
        else if (Input.GetAxisRaw("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            //anim.SetTrigger("Attack");
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            //spawn an arrow
        }
    }

    private void OnTriggerrEnter(Collider other)
    {
        anim.SetTrigger("Die");
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
    }
}
