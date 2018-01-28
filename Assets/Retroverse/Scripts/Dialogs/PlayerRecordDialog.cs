using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class PlayerRecordDialog : Dialog {
	
		[SerializeField]
		private AudioSource audio;

		[SerializeField]
		private Waveform waveform;

		[SerializeField]
		private Text countdownText, repeatPhraseText;

		[SerializeField]
		private Round round;

		private float recordTime = 3f, countdownTime = 3f;
		
		ClipRecording clipRecording;

		private float playTimer, countdownTimer;

		private bool isCountdown, recorded;

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
		void Start () {
			Restart();
			StartCountdown();
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