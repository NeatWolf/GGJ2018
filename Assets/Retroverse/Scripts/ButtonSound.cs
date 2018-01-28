using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

	private Button button;

	[SerializeField]
	private AudioClip sound;


	private void PlaySound () {
		AudioSource.PlayClipAtPoint(sound, transform.position, 0.8f);
	}

	void Awake() {
		button = GetComponent<Button>();
	}

	// Use this for initialization
	void Start () {
		button.onClick.AddListener(PlaySound);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
