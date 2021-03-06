using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;

public class ArcherController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    [SerializeField]
    GameObject spawnPoint;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float arrow_speed = 10;

    DateTime lastSpawnTime = DateTime.Now.AddMilliseconds(-100000000);
    // Start is called before the first frame update
    [SerializeField]
    int TimeBetweenShots = 2000; //milliseconds
    
    [SerializeField]
    float arrow_spin_speed = 10;

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            //only allow a shot if it's been the right amount of time since the last shot
            if((DateTime.Now - lastSpawnTime).TotalMilliseconds > TimeBetweenShots) 
            {
                anim.SetTrigger("Attack");
                lastSpawnTime = DateTime.Now;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "poison mist")
        {
            anim.SetTrigger("Die");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            ThirdPersonCharacter characterScript = GetComponentInParent<ThirdPersonCharacter>();
            characterScript.m_MovingTurnSpeed = 0;
            characterScript.m_StationaryTurnSpeed = 0;
        }
    }

    public void FireArrow()
    {
        //spawn an arrow
        GameObject arrow = Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

        Rigidbody arrow_rb = arrow.GetComponent<Rigidbody>();
        arrow_rb.velocity = spawnPoint.transform.forward * arrow_speed;

        //add torque
        arrow_rb.AddTorque(Vector3.right * arrow_spin_speed, ForceMode.Impulse);
        Destroy(arrow, 5);
    }
}
