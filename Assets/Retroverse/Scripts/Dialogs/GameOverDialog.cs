using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {

	public class GameOverDialog : Dialog {
		
		[SerializeField]
		private Text winnerNameText;

		[SerializeField]
		private Image winnerCharImg;

		[SerializeField]
		Button replayButton;

		[SerializeField]
		Button quitButton;

		[SerializeField]
		private Players players;

		[SerializeField]
		private Round round;

		private Player winner;

		public void Awake(){
			replayButton.onClick.AddListener( Replay );
			quitButton.onClick.AddListener( Application.Quit );
		}

		public override void Show() {
			base.Show();
			GetWinner();

			winnerNameText.text = winner.name;
			winnerCharImg.sprite = winner.character.charSprite;
		}

		public void GetWinner () {
			players.FirstPlayer();

			Player maxScorePlayer = players.CurrentPlayer();

			for (int i=0; i<players.NumPlayers(); i++) {
				Player player = players.GetPlayerAt(i);

				if (maxScorePlayer.score < player.score)
					maxScorePlayer = player;
			}

			winner = maxScorePlayer;
		}


		public void Replay()
		{
			round.roundNum = 1;
		}
	
	}

}