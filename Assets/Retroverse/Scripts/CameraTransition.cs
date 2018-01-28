using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GGJ2018 {
	public class CameraTransition : MonoBehaviour {

		[SerializeField]
		float delay;

		[SerializeField]
		float duration;

		[SerializeField]
		Vector3 position;

		[SerializeField]
		Vector3 rotation;

		[SerializeField]
		float fieldOfView;

		[SerializeField]
		DialogTransistion transition;

		Camera targetCam;

		[SerializeField]
		bool movePosition;

		[SerializeField]
		bool changeRotation;

		[SerializeField]
		bool changeFOV;


		public void Awake()
		{
			targetCam = GetComponentInParent<Camera>();
			transition.ShowBeginEvent += OnShowBegin; 	
		}

		private void OnShowBegin(Dialog dialog)
		{
			StartCoroutine( ShowDialog(dialog) );
		}

		IEnumerator ShowDialog(Dialog dialog){
			float remaining = duration;
			Vector3 startPos = targetCam.transform.position;
			Quaternion startRotation = targetCam.transform.rotation;
			Quaternion endRotation = Quaternion.Euler(rotation);
			float startFOV = targetCam.fieldOfView;

			yield return new WaitForSeconds(delay);

			while( remaining > 0 ){
				yield return null;
				remaining -= Time.deltaTime;
				if( remaining < 0 )
					remaining = 0;
				float t = HermiteEase( 1f-remaining/delay );
				if( changeRotation ){
					targetCam.transform.rotation = Quaternion.Lerp(startRotation,endRotation,t);
				}
				if( movePosition ){
					targetCam.transform.position = Vector3.Lerp(startPos, position, t);
				}
				if( changeFOV ){
					targetCam.fieldOfView = Mathf.Lerp( startFOV, fieldOfView, t  );
				}
				
			}

			
			Debug.Log("Showing dialog");
			dialog.Show();

			transition.ShowComplete();
		}

		float HermiteEase(float x, float edge0 = 0, float edge1 = 1){

			float t = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
			t = t * t * (3.0f - 2.0f * t);
			return t;
		}
	}
}