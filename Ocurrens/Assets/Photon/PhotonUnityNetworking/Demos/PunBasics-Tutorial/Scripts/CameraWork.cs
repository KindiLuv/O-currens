using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	public class CameraWork : MonoBehaviour
	{
		Transform cameraTransform;
        
		bool isFollowing;
		
		void LateUpdate()
		{
			if (cameraTransform == null && isFollowing)
			{
				OnStartFollowing();
			}
			
			if (isFollowing) {
				Follow ();
			}
		}
		
		public void OnStartFollowing()
		{	      
			cameraTransform = Camera.main.transform;
			isFollowing = true;
			Cut();
		}
		
		void Follow()
		{
			cameraTransform.position = transform.position + new Vector3(0, 2, 0);
			cameraTransform.LookAt(transform.position + transform.forward + new Vector3(0, 2, 0));
		}
		
		void Cut()
		{
			cameraTransform.position = transform.position + new Vector3(0, 2, 0);
			cameraTransform.LookAt(transform.position + transform.forward + new Vector3(0, 2, 0));
		}
	}
}
