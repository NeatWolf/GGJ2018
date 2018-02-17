using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018
{
	public class DifficultyDialog : Dialog {
		[SerializeField]
		DialogTransistion transition;

		[SerializeField]
		Dialog nextDialog;

		[SerializeField]
		Questions[] questionsByDifficulty;

		[SerializeField]
		GameState gameState;
				
		public void SelectDifficulty(int i){
			gameState.currentQuestions = questionsByDifficulty[i];
			transition.Show( nextDialog );
			Hide();
		}

	}


}
