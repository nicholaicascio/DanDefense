using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalAnimationControl : NetworkBehaviour {


    public Animator anim;
    public GameObject[] animationBodyParts;
    //public Material invisible;

    [SyncVar(hook = "OnAnimationStateChange")]
    public string animState = "idle";

     

    void OnAnimationStateChange(string aString)
    {
        if (isLocalPlayer) return;
        UpdateAnimation(aString);
    }

    void UpdateAnimation(string aString)
    {
        
        //Debug.Log(animState);
        if (animState == aString) return;
        animState = aString;

        if(animState == "idle")
        {
            anim.Play("idle");
        }

        if(animState == "shoot")
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }

        if (animState == "guard")
        {
            anim.SetBool("Guard", true);
        }
        else
        {
            anim.SetBool("Guard", false);
        }

        if (animState == "run")
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

    }

    
    

    [Command]
    public void CmdUpdateAnim(string aString)
    {
        UpdateAnimation(aString);
    }

    
    


   /* void Start () {
        //anim = GetComponentInChildren<Animator>();
        //anim.SetBool("Idle", true);

        if (isLocalPlayer)
        {
            foreach(GameObject g in animationBodyParts)
            {
                SkinnedMeshRenderer[] m = g.GetComponentsInChildren<SkinnedMeshRenderer>();
                Renderer[] r = g.GetComponentsInChildren<Renderer>();
                foreach(SkinnedMeshRenderer matRend in m)
                {
                    //matRend.material = invisible;
                }

                foreach(Renderer rend in r)
                {
                   //rend.material = invisible;
                }
            }
        }
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}
}
