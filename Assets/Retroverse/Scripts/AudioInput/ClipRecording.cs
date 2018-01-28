using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipRecording {

	private AudioClip clip;

	private float recordTime;

	private bool isPlaying, isRecording;

	private float playDir;

	public void RecordClip (float _recordTime) {
		recordTime = _recordTime;
		clip = Microphone.Start(Microphone.devices[0], false, Mathf.CeilToInt(recordTime), 44100);
		isRecording = true;
	}

	public void StopRecording () {
		Microphone.End(Microphone.devices[0]);
		isRecording = false;
	}

	public void PlayClipForwards (AudioSource src, float time) {
		if (isRecording || clip == null || time >= recordTime - 0.1f)
			return;
		
		src.Stop();

		src.clip = clip;
		src.time = time + 0.05f;
		src.pitch = 1;

		src.Play();

		isPlaying = true;
		playDir = src.pitch;
	}
	
	public void PlayClipBackwards(AudioSource src){
		PlayClipBackwards(src,recordTime);
	}
	public void PlayClipBackwards (AudioSource src, float time) {
		if (isRecording || clip == null || time <= 0.1f)
			return;

		src.Stop();

		src.clip = clip;
		//src.time = clip.length - (clip.length-recordTime) - 0.05f;
		src.time = time - 0.05f;
		src.pitch = -1;

		src.Play();

		isPlaying = true;
		playDir = src.pitch;
	}

	public void StopClip (AudioSource src) {
		src.Stop();
		playDir = 0;
	}

	public AudioClip GetAudioClip () {
		return clip;
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
		
	}
}
