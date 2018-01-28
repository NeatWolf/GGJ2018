using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018 {
	public class RoundEndDialog : Dialog {

		[SerializeField]
		private GameObject scorePanel;

		[SerializeField]
		private Questions questions;

		[SerializeField]
		private Players players;

		[SerializeField]
		private Round round;

		private List<int> scoresThisRound = new List<int>();

		public override void Show() {
			base.Show();
			CalculateScores();
		}

		public void CalculateScores () {
			string answer = questions.CurrentQuestion().answer;
			int maxDistance = answer.Length;
			

			players.FirstPlayer();
			int i = 0;

			bool lastPlayer = false;
			
			while(!lastPlayer) {
				int playerDistance = Levenshtein.Distance(round.guesses[i], answer);
				float percent = Mathf.Clamp01((1f - (playerDistance/maxDistance)));
				int score = Mathf.RoundToInt(percent  * 100);

				scoresThisRound.Add(score);
				
				players.CurrentPlayer().score += score;

				ScorePanel newPanel = Instantiate(scorePanel, scorePanel.transform.position, Quaternion.identity).GetComponent<ScorePanel>();

				newPanel.charImg.sprite = players.CurrentPlayer().character.charSprite;
				newPanel.playerName.text = players.CurrentPlayer().name;
				newPanel.scoreThisRound.text = score.ToString();
				newPanel.totalScore.text = players.CurrentPlayer().score.ToString();

				lastPlayer = players.NextPlayer();
				i+=1;
			}
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}