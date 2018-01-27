using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceRecord : MonoBehaviour {

	[SerializeField]
	private float recordTime;

	[SerializeField]
	private Dropdown micDrop;

	private float timer;
	bool reversePlaying = false;

	private string micName;

	private AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		UpdateMicList();
		SetMic();
		PlayAudioRealtime();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= recordTime && !reversePlaying) {
			PlayAudioBackwards();
			reversePlaying = true;
		}
	}

	private void UpdateMicList () {
		micDrop.ClearOptions();
		micDrop.AddOptions(new List<string>(Microphone.devices));

	}

	public void SetMic () {
		micName = micDrop.options[micDrop.value].text;

	}

	private void PlayAudioRealtime () {
		audio.Stop();

		audio.clip = Microphone.Start(micName, true, Mathf.RoundToInt(recordTime), 44100);
		audio.loop = true;
		//audio.time = 0;

		/*while (!(Microphone.GetPosition(null) > 0)){}
		audio.Play();*/
	}

	private void PlayAudioBackwards () {
		Microphone.End(micName);
		audio.Stop();

		audio.loop = false;
		audio.pitch = -1;
		audio.time = audio.clip.length-0.05f;

		Debug.Log(audio.clip.length);

		audio.Play();
	}
}
