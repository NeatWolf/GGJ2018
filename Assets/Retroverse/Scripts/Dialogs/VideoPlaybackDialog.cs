using System.Collections;
using System.Collections.Generic;
using GGJ2018;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlaybackDialog : Dialog {

	[SerializeField]
	DialogTransistion transition;

	[SerializeField]
	Dialog nextDialog;

	[SerializeField]
	VideoPlayer videoPlayer;

	[SerializeField]
	Questions questions;

	void Start () {
		
	}
	
	void Update () {
		
	}

	override public void Show(){
		base.Show();
		
	}
}
