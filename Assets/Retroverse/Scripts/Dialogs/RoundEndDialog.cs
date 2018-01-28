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
			ScorePanel speakingScorePanel = null;

			int pointsForSpeaker = 0;
			for(int i=0;i<numPlayers;i++) {
				Player player = players.GetPlayerAt(i);
				Debug.Log("<b>" + player.name + "</b>");
				int score = 0;

				ScorePanel newPanel = Instantiate<ScorePanel>(scorePanel, scoreBoardContainer);

				if( player == speakingPlayer && numPlayers > 1 ){
					speakingScorePanel = newPanel;
				}
				else {
					int playerDistance = round.guesses[j].LevenshteinDistance(answer);
					Debug.LogFormat("Distance: {0}", playerDistance.ToString());

					float percent = Mathf.Clamp01((1f - (1f*playerDistance/maxDistance)));
					Debug.LogFormat("Percent: {0}", percent.ToString());
					
					score = Mathf.RoundToInt(percent  * 100);
					player.score += score;

					if (score >= 50)
						pointsForSpeaker += settings.speakerPointBonus;

					j+=1;
				}
				
				Debug.LogFormat("Round score: {0}, Total score: {1}", score, player.score);

				newPanel.charImg.sprite = player.character.charSprite;
				newPanel.playerName.text = player.name;
				newPanel.scoreThisRound.text = score.ToString();
				newPanel.totalScore.text = player.score.ToString();

				
			}

			speakingPlayer.score += pointsForSpeaker;

			speakingScorePanel.background.color = settings.speakerPanelColor;
			speakingScorePanel.scoreThisRound.text = pointsForSpeaker.ToString();
			speakingScorePanel.totalScore.text = speakingPlayer.score.ToString();

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

		public override void Hide() {
			base.Hide();
			while (scoreBoardContainer.childCount > 0) {
				GameObject child = scoreBoardContainer.GetChild(0).gameObject;
				child.transform.SetParent(null);
				Destroy(child);
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