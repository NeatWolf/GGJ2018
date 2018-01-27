using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipRecording : MonoBehaviour {

	private AudioClip clip;

	private float recordTime, timer;

	private bool isRecording;

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
	}
	
	public void PlayClipBackwards (AudioSource src) {
		if (isRecording)
			return;

		src.Stop();

		src.time = src.clip.length - (src.clip.length-recordTime) - 0.05f;
		src.pitch = -1;

		src.Play();
	}

	public bool IsRecording() {
		return isRecording;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < recordTime)
			timer += Time.deltaTime;

		if (timer >= recordTime && isRecording) {
			Microphone.End(Microphone.devices[0]);
			isRecording = false;
		}

	}
}
