using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ToonSoldierScriptv2 : NetworkBehaviour
{
    Animator anim;
    LocalAnimationControl lAnCtrl;

    //int runStateHash = Animator.StringToHash("Base Layer.Run");

    // Use this for initialization
    void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        lAnCtrl = GetComponent<LocalAnimationControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        bool move = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        
        
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        //anim.SetBool("Sprint", sprint);
        bool guard = Input.GetKey(KeyCode.E);
        //anim.SetBool("Guard", guard);
        bool shoot = Input.GetButton("Fire1");
        //anim.SetBool("Shoot", shoot);

        if (move)
        {
            lAnCtrl.CmdUpdateAnim("run");
        }
        else if (shoot)
        {
            lAnCtrl.CmdUpdateAnim("shoot");
        }
        else if (guard)
        {
            lAnCtrl.CmdUpdateAnim("guard");
        }
        else if (sprint)
        {
            lAnCtrl.CmdUpdateAnim("sprint");
        }
        else
        {
            lAnCtrl.CmdUpdateAnim("idle");
        }
       

        
    }
}
