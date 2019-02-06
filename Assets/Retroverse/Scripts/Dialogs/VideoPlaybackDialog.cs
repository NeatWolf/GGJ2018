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
	GameState gameState;

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
		StartCoroutine( Play() );
	}

	IEnumerator Play(){
		repeatButton.gameObject.SetActive(false);
		continueButton.gameObject.SetActive(false);
		videoPlayer.loopPointReached -= OnComplete;
		videoPlayer.clip = playQuestionForwards ?  gameState.currentQuestions.CurrentQuestion().videoClipForward : gameState.currentQuestions.CurrentQuestion().videoClipReverse;
		videoPlayer.loopPointReached += OnComplete;
		//Debug.Log("prepared!");
		//videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		//videoPlayer.EnableAudioTrack(0, true);		
		videoPlayer.SetTargetAudioSource( 0, videoPlayer.gameObject.GetComponent<AudioSource>() );		
		videoPlayer.Prepare();
		yield return new WaitUntil( ()=>videoPlayer.isPrepared );
		
		videoPlayer.Play();


		UpdateText();
		yield break;
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
		StartCoroutine( Play() );
	}

	void NextDialog()
	{
		Hide();
		videoPlayer.Stop();
		transition.Show( nextDialog );
	}
}
