using System;
using System.Collections;
using System.Collections.Generic;
using GGJ2018;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
public class SimpleVideoDialog : Dialog {


	[SerializeField]
	VideoPlayer videoPlayer;

	[SerializeField]
	VideoClip clip;

    [SerializeField]
	AudioSource audioSource;

	[SerializeField]
	DialogTransistion transistion;

	[SerializeField]
	Dialog nextDialog;

	[SerializeField]
	bool transistionImmediately;


    override public void Show(){
		
		base.Show();
		StartCoroutine( Play() );		
	}

	public override void Hide(){
		base.Hide();
		videoPlayer.Stop();
	}

	public IEnumerator Play(){
		videoPlayer.loopPointReached -= OnComplete;
		base.Show();
		videoPlayer.clip = clip;
		videoPlayer.loopPointReached += OnComplete;
		videoPlayer.SetTargetAudioSource( 0, audioSource );
		videoPlayer.Prepare();
		yield return new WaitUntil( ()=>videoPlayer.isPrepared );
		videoPlayer.Play();
		if( transistionImmediately ){
			transistion.Show( nextDialog );

		}  
	}



    private void OnComplete(VideoPlayer source)
    {
        Hide();
		if( !transistionImmediately ){
			transistion.Show( nextDialog );
		}  

    }
}
