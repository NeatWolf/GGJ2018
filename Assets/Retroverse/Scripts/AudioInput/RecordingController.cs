using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingController : MonoBehaviour {

	[SerializeField]
	private float recordTime;

	[SerializeField]
	private Waveform waveform;

	ClipRecording clipRecording;

	private AudioSource audioSrc;

	private float timer;

	public void Record () {

		clipRecording.RecordClip(recordTime);
	}

	public void PlayForwards () {
		clipRecording.PlayClipForwards(audioSrc, timer);
	}

	public void PlayBackwards () {
		clipRecording.PlayClipBackwards(audioSrc, timer);
	}

	public void Restart () {
		audioSrc.Stop();

		clipRecording = new ClipRecording();
		
		waveform.SetClipRecording(clipRecording);

		waveform.ClearWaveform();

		timer = 0;

	}

	void Awake () {
		audioSrc = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		Restart();
	}
	
	// Update is called once per frame
	void Update () {
		if (clipRecording.IsRecording()) {
			timer += Time.deltaTime;

			waveform.DrawWaveform();

			if (timer >= recordTime)
				clipRecording.StopRecording();

		} else if (clipRecording.IsPlaying()) {
			if (clipRecording.GetPlayDir() > 0) {
				if (timer < recordTime)
					timer += Time.deltaTime;

				if (timer >= recordTime) {
					clipRecording.StopClip(audioSrc);
				}
			} else if (clipRecording.GetPlayDir() < 0) {
				if (timer > 0)
					timer -= Time.deltaTime;

				if (timer <= 0) {
					clipRecording.StopClip(audioSrc);
				}				
			}

		}
		waveform.SetPlayhead(timer/recordTime);

	}

}
