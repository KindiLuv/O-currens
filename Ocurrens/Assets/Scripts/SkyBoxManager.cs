using Photon.Pun;
using UnityEngine;

public class SkyBoxManager : MonoBehaviourPun
{
    [SerializeField] private Material skybox1;
    [SerializeField] private Material skybox2;
    
    // Start is called before the first frame update
    void Start()
    {
        //RenderSettings.skybox = skybox1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            photonView.RPC("SwapSkybox", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void SwapSkybox()
    {
        RenderSettings.skybox = RenderSettings.skybox == skybox1 ? skybox2 : skybox1;
    }
}
