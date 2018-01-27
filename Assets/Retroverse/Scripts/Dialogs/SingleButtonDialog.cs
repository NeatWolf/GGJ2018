using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GGJ2018 {
	public class SingleButtonDialog : Dialog {

		[SerializeField]
		Button button;

		[SerializeField]
		Dialog nextDialog;

		[SerializeField]
		DialogTransistion transistion;

		public override void Init(){

			button.onClick.AddListener( ()=>{
				Hide();
				transistion.Show( nextDialog );
			});
		}
	
	}
}