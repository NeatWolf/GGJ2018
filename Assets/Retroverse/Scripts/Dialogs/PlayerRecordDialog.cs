using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class PlayerRecordDialog : Dialog {
	
		[SerializeField]
		private new AudioSource audio;

		[SerializeField]
		private Waveform waveform;

		[SerializeField]
		private Text countdownText;
		
		[SerializeField]
		Text repeatPhraseText;

		[SerializeField]
		private Text nameField;

		[SerializeField]
		private Image characterImage;

		[SerializeField]
		Players players;

		[SerializeField]
		private Round round;

		[SerializeField]
		Dialog nextDialog;

		[SerializeField]
		DialogTransistion transistion;

		private float recordTime = 3f, countdownTime = 3f;
		
		ClipRecording clipRecording;

		private float playTimer, countdownTimer;

		private bool isCountdown, recorded, playedBackwards;

		public void StartCountdown () {
			countdownTimer = 0;
			//waveform.gameObject.SetActive(true);
			isCountdown = true;
		}

		public void Record () {
			clipRecording.RecordClip(recordTime);
		}

		public void PlayForwards () {
			clipRecording.PlayClipForwards(audio, playTimer);
		}

		public void PlayBackwards () {
			clipRecording.PlayClipBackwards(audio, playTimer);
		}

		public void Restart () {
			audio.Stop();

			recorded = false;
			playedBackwards = false;

			clipRecording = new ClipRecording();
			
			waveform.SetClipRecording(clipRecording);

			waveform.gameObject.SetActive(true);
			waveform.ClearWaveform();
			//waveform.gameObject.SetActive(false);

			repeatPhraseText.gameObject.SetActive(true);

			playTimer = 0;

		}

		void Awake () {

		}

		// Use this for initialization
		override public void Show () {
			round.guesses.Clear();
			characterImage.sprite = players.CurrentPlayer().character.charSprite;
			nameField.text = players.CurrentPlayer().name;
			base.Show();
			Restart();
			StartCountdown();			
		}

		override public void Hide(){
			base.Hide();
			waveform.gameObject.SetActive(false);
		}
		
		// Update is called once per frame
		void Update () {
			if (isCountdown) {
				countdownTimer += Time.deltaTime;

				if (countdownTimer >= countdownTime) {
					isCountdown = false;
					countdownText.text = "";
					Record();
				} else {
					countdownText.text = Mathf.CeilToInt(countdownTime-countdownTimer).ToString();
				}

			} else if (clipRecording.IsRecording() && !recorded) {
				playTimer += Time.deltaTime;

				waveform.DrawWaveform();

				if (playTimer >= recordTime) {
					CompleteRecording();
				}

			} else if (clipRecording.IsPlaying()) {
				if (clipRecording.GetPlayDir() > 0) {
					if (playTimer < recordTime)
						playTimer += Time.deltaTime;

					if (playTimer >= recordTime) {
						clipRecording.StopClip(audio);
					}
				} else if (clipRecording.GetPlayDir() < 0) {
					if (playTimer > 0)
						playTimer -= Time.deltaTime;

					if (playTimer <= 0) {
						clipRecording.StopClip(audio);
						if (!playedBackwards) {
							playedBackwards = true;
							transistion.Show(nextDialog);
							Hide();
						}
					}
				}

			}
			waveform.SetPlayhead(playTimer/recordTime);

		}

		private void CompleteRecording () {
			clipRecording.StopRecording();
			recorded = true;

			round.playerRecording = clipRecording;
			repeatPhraseText.gameObject.SetActive(false);

			playTimer = recordTime;
			PlayBackwards();
		}
	}
}