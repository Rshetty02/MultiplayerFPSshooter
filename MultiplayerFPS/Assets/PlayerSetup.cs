﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    
    [SerializeField]
    Behaviour[] componentsToDisable;
    Camera scenecamera;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer){
        for(int i=0;i<componentsToDisable.Length;i++){
            componentsToDisable[i].enabled = false;
        }
        }
        else{

            scenecamera = Camera.main;
            if(scenecamera != null){
                scenecamera.gameObject.SetActive(false);

            }

        }
    }


    private void OnDisable() {
        if(scenecamera != null){
            scenecamera.gameObject.SetActive(true);
        }
    }

}
