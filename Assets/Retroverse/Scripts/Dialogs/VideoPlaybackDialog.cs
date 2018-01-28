using System;
using System.Collections;
using System.Collections.Generic;
using GGJ2018;
using UnityEngine;
using UnityEngine.UI;
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

	[SerializeField]
	Button repeatButton;

	[SerializeField]
	Button continueButton;

	[SerializeField]
	Text triesTextField;

	[SerializeField]
	Settings settings;

	[SerializeField]
	bool playQuestionForwards = false;

	[SerializeField]
	bool restrictReplays;

	int triesRemaining;

	void Init () 
	{

		
	}

	void Awake()
	{
		continueButton.onClick.RemoveAllListeners();
		repeatButton.onClick.RemoveAllListeners();
		continueButton.onClick.AddListener( NextDialog );
		repeatButton.onClick.AddListener( RepeatVideo );
	}

    void Update () 
	{
		
	}

	override public void Show()
	{
		if(restrictReplays){
			triesRemaining = settings.numberOfTries;
		}
		base.Show();
		Play();
	}

	void Play(){
		videoPlayer.loopPointReached -= OnComplete;
		videoPlayer.clip = playQuestionForwards ?  questions.CurrentQuestion().videoClipForward : questions.CurrentQuestion().videoClipReverse;
		videoPlayer.loopPointReached += OnComplete;

		videoPlayer.SetTargetAudioSource( 0, videoPlayer.gameObject.GetComponent<AudioSource>() );
		videoPlayer.Play();
//		videoPlayer.
		repeatButton.gameObject.SetActive(false);
		continueButton.gameObject.SetActive(false);
		UpdateText();
	}
	
    private void OnComplete(VideoPlayer source)
    {				
		repeatButton.gameObject.SetActive( !restrictReplays || triesRemaining > 0 );
		continueButton.gameObject.SetActive(true);
    }


	private void UpdateText(){
		if(restrictReplays){
			triesTextField.text = string.Format(settings.triesRemainingText, triesRemaining);
		}
	}

	void RepeatVideo(){
		triesRemaining--;
		UpdateText();
		Debug.Log("RepeatVideo");
		Play();
	}

	void NextDialog()
	{
		Hide();
		videoPlayer.Stop();
		transition.Show( nextDialog );
	}
}
