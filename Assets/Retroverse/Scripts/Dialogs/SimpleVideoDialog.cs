using System;
using System.Collections;
using System.Collections.Generic;
using GGJ2018;
using UnityEngine;
using UnityEngine.Video;

public class SimpleVideoDialog : Dialog {


	[SerializeField]
	VideoPlayer videoPlayer;

	[SerializeField]
	VideoClip clip;

    [SerializeField]
	AudioSource audioSource;

    override public void Show(){
		videoPlayer.loopPointReached -= OnComplete;
		base.Show();
		videoPlayer.clip = clip;
		videoPlayer.SetTargetAudioSource( 0, audioSource );
		videoPlayer.Play();
		videoPlayer.loopPointReached += OnComplete;
	}

    private void OnComplete(VideoPlayer source)
    {
        Hide();

    }
}
