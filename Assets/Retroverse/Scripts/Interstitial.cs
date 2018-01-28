using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GGJ2018 {
	public class Interstitial : MonoBehaviour {

		[SerializeField]
		float delay;

		[SerializeField]
		DialogTransistion transition;

		public void Awake()
		{
			transition.ShowBeginEvent += OnShowBegin; 	
		}

		private void OnShowBegin(Dialog dialog)
		{
			StartCoroutine( ShowDialog(dialog) );
		}

		IEnumerator ShowDialog(Dialog dialog){
			yield return new WaitForSeconds(delay);
			dialog.Show();
		}
	}
}