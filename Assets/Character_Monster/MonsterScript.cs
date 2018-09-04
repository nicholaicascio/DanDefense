using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        bool attack = Input.GetKey(KeyCode.Z);
        anim.SetBool("Attack", attack);

        bool jump = Input.GetKey(KeyCode.X);
        anim.SetBool("Jump", jump);

        bool die = Input.GetKey(KeyCode.C);
        anim.SetBool("Die", die);

        bool life = Input.GetKeyDown(KeyCode.V);
        anim.SetBool("Life", life);
    }
}
