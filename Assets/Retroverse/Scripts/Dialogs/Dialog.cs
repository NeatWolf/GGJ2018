using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GGJ2018 {
	public class Dialog : MonoBehaviour {

			 [SerializeField]
			AudioMixerSnapshot musicSnapshot;	 

		public virtual void Init(){

		}

		public virtual void Show(){
			if(musicSnapshot!=null){
				musicSnapshot.TransitionTo(0);
			}
			gameObject.SetActive(true);
		}

		public virtual void Hide(){
			gameObject.SetActive(false);
		}
	}


}