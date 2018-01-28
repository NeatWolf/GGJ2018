using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class StartDialog : Dialog {

		[SerializeField]
		private Button startButton, creditsButton;

		[SerializeField]
		private Dialog numPlayersDialog, creditsDialog;
		
		[SerializeField]
		private DialogTransistion transistion;

		public void LoadCredits () {
			Hide();
			transistion.Show(creditsDialog);
		}

		public void LoadNumPlayers () {
			Hide();
			transistion.Show(numPlayersDialog);
		}

		public override void Init(){

			startButton.onClick.AddListener( ()=>{
				LoadNumPlayers();
			});

			creditsButton.onClick.AddListener( ()=> {
				LoadCredits();
			});
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}