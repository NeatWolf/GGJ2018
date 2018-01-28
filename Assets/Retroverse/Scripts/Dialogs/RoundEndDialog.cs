using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018 {
	public class RoundEndDialog : Dialog {

		[SerializeField]
		private ScorePanel scorePanel;

		[SerializeField]
		private Questions questions;

		[SerializeField]
		private Players players;

		[SerializeField]
		private Round round;

		[SerializeField]
		private Settings settings;


		[SerializeField]
		private Dialog roundBeginDialog, gameOverDialog;

		[SerializeField]
		private DialogTransistion transition;

		[SerializeField]
		private Transform scoreBoardContainer;

		public override void Show() {
			base.Show();
			CalculateScores();
		}

		public void CalculateScores () {
			string answer = questions.CurrentQuestion().answer;
			int maxDistance = answer.Length;
			

			players.FirstPlayer();

			int numPlayers = players.NumPlayers();

			Debug.Log(numPlayers);
			int j=0;
			Player speakingPlayer = players.CurrentPlayer();
			for(int i=0;i<numPlayers;i++) {
				Player player = players.GetPlayerAt(i);
				Debug.Log("<b>" + player.name + "</b>");
				int score = 0;
				if( player == speakingPlayer && numPlayers > 1 ){
					
				}
				else {
<<<<<<< HEAD
					int playerDistance = Levenshtein.Distance(round.guesses[j], answer);
					Debug.Log("Guess: " + round.guesses[j]);
					float percent = Mathf.Clamp01((1f - (1f*playerDistance/maxDistance)));

					Debug.LogFormat("player distance: {0}, max distance: {1}", playerDistance, maxDistance);
					Debug.Log("(playerDistance/maxDistance): " + (playerDistance/maxDistance));
=======
					int playerDistance = round.guesses[j].LevenshteinDistance(answer);
					Debug.LogFormat("Distance: {0}", playerDistance.ToString());

					float percent = Mathf.Clamp01((1f - (1f*playerDistance/maxDistance)));
					Debug.LogFormat("Percent: {0}", percent.ToString());
					
>>>>>>> c219fd69cd75c9481a17391b776eb6b4b70989c2
					score = Mathf.RoundToInt(percent  * 100);
					player.score += score;
					j+=1;
				}
				
<<<<<<< HEAD
=======
				Debug.LogFormat("Round score: {0}, Total score: {1}", score, player.score);
				
>>>>>>> c219fd69cd75c9481a17391b776eb6b4b70989c2
				ScorePanel newPanel = Instantiate<ScorePanel>(scorePanel, scoreBoardContainer);

				newPanel.charImg.sprite = player.character.charSprite;
				newPanel.playerName.text = player.name;
				newPanel.scoreThisRound.text = score.ToString();
				newPanel.totalScore.text = player.score.ToString();

				
			}
		}

		public void NextDialog () {
			Hide();

			Dialog nextDialog;

			if (round.roundNum >= settings.numberOfRounds) {
				nextDialog = gameOverDialog;
			} else {
				round.roundNum += 1;
				nextDialog = roundBeginDialog;
			}
			transition.Show(nextDialog);
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}