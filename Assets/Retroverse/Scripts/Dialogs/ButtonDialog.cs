using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class ButtonDialog : Dialog {

		[SerializeField]
		private DialogButton[] buttons;
		
		[SerializeField]
		private DialogTransistion transistion;
		
		public void Show(Dialog dialog){
			Hide();
			transistion.Show(dialog);
		}

		public override void Init(){

			System.Array.ForEach( buttons, AddButtonListener );

		}

		private void AddButtonListener(DialogButton dButton){
			//Debug.LogFormat("{0} Attaching listener to {1} ",this.name,dButton.button.name);
			dButton.button.onClick.AddListener( ()=>{
				Show(dButton.dialog);
			});
		}
		
	}

	[System.Serializable]
	public class DialogButton{
		public Button button;
		public Dialog dialog;
	}
}