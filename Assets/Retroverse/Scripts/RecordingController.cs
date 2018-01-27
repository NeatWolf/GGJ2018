using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingController : MonoBehaviour {

	[SerializeField]
	private float recordTime;

	[SerializeField]
	private Waveform waveform;

	ClipRecording clipRecording;

	private AudioSource audio;

	private float timer;

	void Awake () {
		clipRecording = new ClipRecording();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (clipRecording.IsRecording()) {
			timer += Time.deltaTime;

			if (timer >= recordTime)
				clipRecording.StopRecording();

		} else if (clipRecording.IsPlaying()) {
			if (clipRecording.GetPlayDir() > 0) {
				if (timer < recordTime)
					timer += Time.deltaTime;

				if (timer >= recordTime) {
					clipRecording.StopClip(audio);
				}
			} else if (clipRecording.GetPlayDir() < 0) {
				if (timer > 0)
					timer -= Time.deltaTime;

				if (timer <= 0) {
					clipRecording.StopClip(audio);
				}				
			}
		}

		


	}

	
}
