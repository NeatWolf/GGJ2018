using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipRecording {

	[SerializeField]
	private Waveform waveform;

	private AudioClip clip;

	private float recordTime, timer;

	private bool isPlaying, isRecording;

	private float playDir;

	public void RecordClip (float _recordTime) {
		isRecording = true;
		recordTime = _recordTime;
		clip = Microphone.Start(Microphone.devices[0], false, Mathf.CeilToInt(recordTime), 44100);
	}

	public void PlayClipForwards (AudioSource src) {
		if (isRecording)
			return;

		src.Stop();

		src.time = 0;
		src.pitch = 1;

		src.Play();

		timer = 0;

		isPlaying = true;
		playDir = src.pitch;
	}
	
	public void PlayClipBackwards (AudioSource src) {
		if (isRecording)
			return;

		src.Stop();

		src.time = src.clip.length - (src.clip.length-recordTime) - 0.05f;
		src.pitch = -1;

		src.Play();

		timer = 1;

		isPlaying = true;
		playDir = src.pitch;
	}

	public bool IsPlaying() {
		return isPlaying;
	}

	public float GetPlayDir () {
		return playDir;
	}

	public bool IsRecording() {
		return isRecording;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playDir > 0) {
			if (timer < recordTime) {
				timer += Time.deltaTime;
				waveform.GetWaveform(clip);
			}

			if (timer >= recordTime && isRecording) {
				Microphone.End(Microphone.devices[0]);
				isRecording = false;
				playDir = 0;
			}
		}

		if (playDir < 0) {
			if (timer > 0)
				timer -= Time.deltaTime;

			if (timer <= 0)
				playDir = 0;
		}

		waveform.SetPlayhead(timer/clip.length);
	}
}
