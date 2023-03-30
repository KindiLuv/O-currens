using UnityEngine;

public class MyCameraScript : MonoBehaviour
{
    private Transform myCamera;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main.transform;
        myCamera.SetParent(transform);
        myCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
        myCamera.transform.position = new Vector3(0, 6.75f, 0);
    }
}
