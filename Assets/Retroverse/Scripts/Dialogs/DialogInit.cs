using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ2018 {
	public class DialogInit : MonoBehaviour {

		[SerializeField]
		Dialog[]  dialogs;

		// Use this for initialization
		void Awake () {
			foreach(var dialog in dialogs){
				dialog.Init();
				dialog.gameObject.SetActive(false);
			}
			dialogs[0].gameObject.SetActive(true);
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}