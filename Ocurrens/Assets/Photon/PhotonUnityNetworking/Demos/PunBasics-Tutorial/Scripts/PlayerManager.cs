using System;
using System.Collections;
using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	#pragma warning disable 649

    /// <summary>
    /// Player manager.
    /// Handles fire Input and Beams.
    /// </summary>
    public class PlayerManager : MonoBehaviourPunCallbacks
    {
        #region Public Fields

        [SerializeField] private GameObject Canvass;
        [SerializeField] private GameObject OkImage;
        [SerializeField] private GameObject WrongImage;

        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        public void Awake()
        {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instanciation when levels are synchronized
            if (photonView.IsMine)
            {
                LocalPlayerInstance = gameObject;
            }

            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(gameObject);
        }
        
        public void Start()
        {
            CameraWork _cameraWork = gameObject.GetComponent<CameraWork>();

            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                }
            }
            else
            {
                Debug.LogError("<Color=Red><b>Missing</b></Color> CameraWork Component on player Prefab.", this);
            }
            /*OkImage.SetActive(false);
            WrongImage.SetActive(false);*/
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                ProcessInputs();
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Processes the inputs. This MUST ONLY BE USED when the player has authority over this Networked GameObject (photonView.isMine == true)
        /// </summary>
        void ProcessInputs()
        {
            if (Input.GetButtonDown("OkImage"))
            {
                StartCoroutine(ImgAppearDisappear(3, OkImage));
            }
            
            if (Input.GetButtonDown("WrongImage"))
            {
                StartCoroutine(ImgAppearDisappear(3, WrongImage));
            }
        }
        
        private IEnumerator ImgAppearDisappear(float timespan, GameObject obj)
        {
            Canvass.transform.position += new Vector3(0, .5f, 0);
            yield return new WaitForSeconds(timespan);
            obj.SetActive(false);
            yield return new WaitForSeconds(timespan);
            obj.SetActive(true);
        }

        #endregion
    }
}