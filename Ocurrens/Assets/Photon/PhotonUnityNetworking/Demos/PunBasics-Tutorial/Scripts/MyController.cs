using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MyController : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Prevent control is connected to Photon and represent the localPlayer
        if( photonView.IsMine == false && PhotonNetwork.IsConnected == true )
        {
            Debug.Log("ono");
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("yes");
            transform.position += new Vector3(0, 1, 0);
        }
    }
}
