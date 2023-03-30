// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraWork.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in PUN Basics Tutorial to deal with the Camera work to follow the player
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	/// <summary>
	/// Camera work. Follow a target
	/// </summary>
	public class CameraWork : MonoBehaviour
	{
        #region Private Fields

	    [Tooltip("Set this as false if a component of a prefab being instanciated by Photon Network, and manually call OnStartFollowing() when and if needed.")]
	    [SerializeField]
	    private bool followOnStart = false;
	    
        // cached transform of the target
        Transform cameraTransform;

		// maintain a flag internally to reconnect if target is lost or camera is switched
		bool isFollowing;
		
		// Cache for camera offset
		Vector3 cameraOffset = Vector3.zero;
		
		
        #endregion

        #region MonoBehaviour Callbacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase
        /// </summary>
        void Start()
		{
			// Start following the target if wanted.
			if (followOnStart)
			{
				OnStartFollowing();
			}
		}


		void LateUpdate()
		{
			// The transform target may not destroy on level load, 
			// so we need to cover corner cases where the Main Camera is different everytime we load a new scene, and reconnect when that happens
			if (cameraTransform == null && isFollowing)
			{
				OnStartFollowing();
			}

			// only follow is explicitly declared
			if (isFollowing) {
				Follow ();
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Raises the start following event. 
		/// Use this when you don't know at the time of editing what to follow, typically instances managed by the photon network.
		/// </summary>
		public void OnStartFollowing()
		{	      
			cameraTransform = Camera.main.transform;
			isFollowing = true;
			// we don't smooth anything, we go straight to the right camera shot
			Cut();
		}
		
		#endregion

		#region Private Methods

		/// <summary>
		/// Follow the target smoothly
		/// </summary>
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
		#endregion
	}
}
