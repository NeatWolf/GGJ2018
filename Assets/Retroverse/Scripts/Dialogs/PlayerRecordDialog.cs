using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ2018 {
	public class PlayerRecordDialog : Dialog {
	
	[SerializeField]
	private Waveform waveform;

	private float recordTime = 3f, countdownTime = 3f;

	ClipRecording clipRecording;

	private AudioSource audio;

	private float playTimer, countdownTimer;

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

		clipRecording = new ClipRecording();
		
		waveform.SetClipRecording(clipRecording);

		waveform.ClearWaveform();

		playTimer = 0;

	}

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		Restart();
	}
	
	// Update is called once per frame
	void Update () {
		if (clipRecording.IsRecording()) {
			playTimer += Time.deltaTime;

			waveform.DrawWaveform();

			if (playTimer >= recordTime)
				clipRecording.StopRecording();

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
	}
}