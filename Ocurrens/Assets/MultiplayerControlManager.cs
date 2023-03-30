using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MultiplayerControlManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> myObjects;
    [SerializeField] private GameObject myCapsule;
    [SerializeField] private PhotonView myphotonView;
    // Start is called before the first frame update
    void Start()
    {
        if (myphotonView.IsMine)
        {
            foreach (var obj in myObjects)
            {
                obj.SetActive(true);
            }
            myCapsule.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
