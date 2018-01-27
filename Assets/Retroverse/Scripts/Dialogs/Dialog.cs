using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018 {
	public class Dialog : MonoBehaviour {
		public virtual void Init(){

		}

		public virtual void Show(){
			gameObject.SetActive(true);
		}

		public virtual void Hide(){
			gameObject.SetActive(false);
		}
	}


}