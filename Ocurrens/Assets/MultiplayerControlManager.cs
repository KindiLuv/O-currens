using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerControlManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> myObjects;
    [SerializeField] private GameObject myCapsule;
    [SerializeField] private PhotonView myphotonView;

    [SerializeField] private GameObject ControllerToDisable;
    // Start is called before the first frame update
    void Start()
    {
        if (!myphotonView.IsMine)
        {
            foreach (var obj in myObjects)
            {
                obj.SetActive(false);
            }
            Destroy(ControllerToDisable.GetComponent<FirstPersonController>());
            Destroy(ControllerToDisable.GetComponent<CharacterController>());
            Destroy(ControllerToDisable.GetComponent<StarterAssetsInputs>());
            Destroy(ControllerToDisable.GetComponent<BasicRigidBodyPush>());
            Destroy(ControllerToDisable.GetComponent<PlayerInput>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
