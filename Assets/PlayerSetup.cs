using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componetsToDisable;
    Camera sceneCamera;
    Camera fps;

    public override void OnStartLocalPlayer()
    {
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }

    // Use this for initialization
    void Start () {
       
        if (!isLocalPlayer)
        {
            for(int i = 0; i < componetsToDisable.Length; i++)
            {
                componetsToDisable[i].enabled = false;

            }
        }
        else
        {
             sceneCamera = Camera.main;
             fps = gameObject.GetComponentInChildren<Camera>();
             if (sceneCamera != null && fps != null)
             {
                 sceneCamera.gameObject.SetActive(false);
                 fps.gameObject.SetActive(true);
             }
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