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
		private Dialog nextDialog;

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
					int playerDistance = round.guesses[j].LevenshteinDistance(answer);
					Debug.LogFormat("Distance: {0}", playerDistance.ToString());

					float percent = Mathf.Clamp01((1f - (1f*playerDistance/maxDistance)));
					Debug.LogFormat("Percent: {0}", percent.ToString());
					
					score = Mathf.RoundToInt(percent  * 100);
					player.score += score;
					j+=1;
				}
				
				Debug.LogFormat("Round score: {0}, Total score: {1}", score, player.score);
				
				ScorePanel newPanel = Instantiate<ScorePanel>(scorePanel, scoreBoardContainer);

				newPanel.charImg.sprite = player.character.charSprite;
				newPanel.playerName.text = player.name;
				newPanel.scoreThisRound.text = score.ToString();
				newPanel.totalScore.text = player.score.ToString();

				
			}
		}

		public void NextDialog () {
			Hide();
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