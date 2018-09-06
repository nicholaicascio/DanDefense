using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componetsToDisable;

    Camera sceneCamera;

	// Use this for initialization
	void Start () {
        sceneCamera = Camera.main;
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(false);
        }
        if (!isLocalPlayer)
        {
            for(int i = 0; i < componetsToDisable.Length; i++)
            {
                componetsToDisable[i].enabled = false;
            }
        }
        else
        {
            
        }
	}

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }


}
