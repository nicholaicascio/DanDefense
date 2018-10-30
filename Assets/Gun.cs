﻿
using UnityEngine;

public class Gun : MonoBehaviour {

    public int weaponDamage = 10;
    public float range = 100f;
    public ParticleSystem muzzleFlash;

    public Camera fpsCam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

	}

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Health health = hit.transform.GetComponent<Health>();
            Box box = hit.transform.GetComponent<Box>();

            if (health != null)
            {
                health.TakeDamage(weaponDamage);
                Debug.Log("hit");
            }
            if (box != null)
            {
                box.TakeDamage(weaponDamage);
            }
        }
    }
}
