using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PowerpointImageSwitcher : MonoBehaviourPun
{
    [SerializeField] GameObject displayHud;
    [SerializeField] List<RawImage> _pipoint;
    private RawImage activeRawImage;

    // Start is called before the first frame update
    void Start()
    {
        activeRawImage = _pipoint[0];
        activeRawImage.gameObject.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        // Show/Hide the UI
        if (Input.GetKeyDown(KeyCode.P))
        {
            photonView.RPC("UiSwitch", RpcTarget.AllBuffered);
        }
        
        // Cycle thru rawImages
        if (displayHud.activeInHierarchy)
        {
           if (Input.GetKeyDown(KeyCode.O))
           {
               photonView.RPC("SwitchImage", RpcTarget.AllBuffered);
           } 
        }
    }

    [PunRPC]
    private void UiSwitch()
    {
        displayHud.SetActive(!displayHud.activeInHierarchy);
    }

    [PunRPC]
    private void SwitchImage()
    {
        activeRawImage.gameObject.SetActive(false);
        switch (activeRawImage)
        {
            case not null when activeRawImage == _pipoint[0]:
                activeRawImage = _pipoint[1];
                break;
            case not null when activeRawImage == _pipoint[1]:
                activeRawImage = _pipoint[2];
                break;
            case not null when activeRawImage == _pipoint[2]:
                activeRawImage = _pipoint[0];
                break;
        }
        activeRawImage.gameObject.SetActive(true);
    }
}
