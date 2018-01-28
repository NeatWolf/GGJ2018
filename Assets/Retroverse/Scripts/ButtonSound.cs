using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

	[SerializeField]
	private Button button;

	[SerializeField]
	private AudioClip sound;

	private AudioSource source;

	private void PlaySound () {
		source.PlayOneShot(sound);
	}

	void Awake() {
		source = gameObject.AddComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener(PlaySound);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
