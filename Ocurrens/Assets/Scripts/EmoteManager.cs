using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EmoteManager : MonoBehaviourPun
{
    [SerializeField] private RawImage OkImage;
    [SerializeField] private RawImage WrongImage;

    private void Awake()
    {
        OkImage.enabled = false;
        WrongImage.enabled = false;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            photonView.RPC("EnableImageOK", RpcTarget.AllBuffered, true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            photonView.RPC("EnableImageOK", RpcTarget.AllBuffered, false);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            photonView.RPC("EnableImageWrong", RpcTarget.AllBuffered, true);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            photonView.RPC("EnableImageWrong", RpcTarget.AllBuffered, false);
        }
    }
    
    [PunRPC]
    private void EnableImageOK(bool enable)
    {
        OkImage.enabled = enable;
    }
    
    [PunRPC]
    private void EnableImageWrong(bool enable)
    {
        WrongImage.enabled = enable;
    }
}
