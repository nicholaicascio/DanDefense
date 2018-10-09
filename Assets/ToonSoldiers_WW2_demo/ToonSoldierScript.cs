using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToonSoldierScript : NetworkBehaviour
{
    Animator anim;

    //int runStateHash = Animator.StringToHash("Base Layer.Run");

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        bool shoot = Input.GetButton("Fire1");
        anim.SetBool("Shoot", shoot);

        bool guard = Input.GetKey(KeyCode.E);
        anim.SetBool("Guard", guard);

        bool sprint = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool("Sprint", sprint);
    }
}
