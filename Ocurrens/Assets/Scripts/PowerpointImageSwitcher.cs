using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerpointImageSwitcher : MonoBehaviour
{
    [SerializeField] GameObject displayHud;
    [SerializeField] List<RawImage> _pipoint;
    private RawImage activeRawImage;

    // Start is called before the first frame update
    void Start()
    {
        activeRawImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Show/Hide the UI
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
        
        if (displayHud.activeInHierarchy)
        {
           // Cycle thru rawImages
           if (Input.GetKeyDown(KeyCode.P))
           {
               activeRawImage.enabled = false;
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
               activeRawImage.enabled = true;
           } 
        }
        
    }
}
