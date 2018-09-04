using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componetsToDisable;

    Camera mainCamera;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            for(int i = 0;i<componetsToDisable.Length; i++)
            {
                componetsToDisable[i].enabled = false;
            }
        }else
        {
            mainCamera = Camera.main;
            if(mainCamera != null)
            {
                mainCamera.gameObject.SetActive(false);
            }
            
        }
	}

    void OnDisable()
    {
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }
    }
}
