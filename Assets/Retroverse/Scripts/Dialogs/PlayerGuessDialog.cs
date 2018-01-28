using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ2018 {
	public class PlayerGuessDialog : Dialog {

		[SerializeField]
		Dialog nextDialog;

		[SerializeField]
		DialogTransistion transistion;

		[SerializeField]
		Round round;

		[SerializeField]
		Players players;

		[SerializeField]
		PlayerIterator iterator;

		void Start () {
			
		}
		
		void Update () {
			
		}
	}
}