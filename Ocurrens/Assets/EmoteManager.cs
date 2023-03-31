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
            photonView.RPC("EnableImage", RpcTarget.AllBuffered, true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            photonView.RPC("EnableImage", RpcTarget.AllBuffered, false);
        }
    }
    
    [PunRPC]
    private void EnableImage(bool enable)
    {
        OkImage.enabled = enable;
    }
    
}