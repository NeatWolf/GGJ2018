﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ2018 {
	public class DialogInit : MonoBehaviour {

		[SerializeField]
		Dialog[]  dialogs;

		[SerializeField]
		DialogTransistion transition;
		
		// Use this for initialization
		void Awake () {
			foreach(var dialog in dialogs){
				dialog.Init();
				dialog.gameObject.SetActive(false);
			}
			
		}

		void Start(){
			transition.Show( dialogs[0] );
		}
		

	}
}