using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ2018 {
	public class NumPlayersDialog : Dialog {

		[SerializeField]
		Players players;

		[SerializeField]
		DialogTransistion transition;

		[SerializeField]
		Dialog nextDialog; 

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void SetNumPlayers(int i){
			Hide();
			players.Setup(i);
			transition.Show( nextDialog );
		}
	}
}