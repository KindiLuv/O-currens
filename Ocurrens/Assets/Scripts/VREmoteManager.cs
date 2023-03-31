using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VREmoteManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset ActionAsset;
    [SerializeField] private RawImage OkImage;
    [SerializeField] private RawImage WrongImage;

    private void Awake()
    {
        ActionAsset.FindActionMap("XRI RightHand Interaction").FindAction("EmoteA").performed += OnEmoteA;
        ActionAsset.FindActionMap("XRI RightHand Interaction").FindAction("EmoteB").performed += OnEmoteB;
    }

    private void OnEnable()
    {
        ActionAsset.FindActionMap("XRI RightHand Interaction").Enable();
    }

    private void OnDisable()
    {
        ActionAsset.FindActionMap("XRI RightHand Interaction").Disable();
    }
    
    private void OnEmoteA(InputAction.CallbackContext context)
    {
        Debug.Log("emoteA");
        StartCoroutine(ImgAppearDisappear(3, OkImage.gameObject));
    }
    
    private void OnEmoteB(InputAction.CallbackContext context)
    {
        Debug.Log("emoteB");
        StartCoroutine(ImgAppearDisappear(3, WrongImage.gameObject));
    }

    private static IEnumerator ImgAppearDisappear(float timespan, GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(timespan);
        obj.SetActive(false);
    }
}
