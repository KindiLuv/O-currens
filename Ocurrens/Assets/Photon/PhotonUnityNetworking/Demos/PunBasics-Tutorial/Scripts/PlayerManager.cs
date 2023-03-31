using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
    public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private GameObject OkImage;
        [SerializeField] private GameObject WrongImage;
        
        public static GameObject LocalPlayerInstance;
        
        bool IsOkImage;
        bool isWrongImage;

        public void Awake()
        {
            OkImage.SetActive(false);
            WrongImage.SetActive(false);
            if (photonView.IsMine)
            {
                LocalPlayerInstance = gameObject;
            }
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
        }

        private bool leavingRoom;

        public void Update()
        {
            if (photonView.IsMine)
            {
                ProcessInputs();
            }
            
            if (OkImage != null && IsOkImage != OkImage.activeInHierarchy)
            {
                OkImage.SetActive(IsOkImage);
            }
            
            if (WrongImage != null && isWrongImage != WrongImage.activeInHierarchy)
            {
                WrongImage.SetActive(isWrongImage);
            }
        }

        public override void OnLeftRoom()
        {
            leavingRoom = false;
        }
        
        void ProcessInputs()
        {
            
            if (Input.GetButtonDown("OkImage"))
            {
                if (!IsOkImage)
                {
                    IsOkImage = true;
                }
            }

            if (Input.GetButtonUp("OkImage"))
            {
                if (IsOkImage)
                {
                    IsOkImage = false;
                }
            }
            
            if (Input.GetButtonDown("WrongImage"))
            {
                if (!isWrongImage)
                {
                    isWrongImage = true;
                }
            }

            if (Input.GetButtonUp("WrongImage"))
            {
                if (isWrongImage)
                {
                    isWrongImage = false;
                }
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(IsOkImage);
                stream.SendNext(isWrongImage);
            }
            else
            {
                IsOkImage = (bool)stream.ReceiveNext();
                isWrongImage = (bool)stream.ReceiveNext();
            }
        }
    }
}
