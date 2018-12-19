using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class PlayerGuessDialog : Dialog {

		[SerializeField]
		Dialog nextDialog;

		[SerializeField]
		DialogTransistion transistion;

		[SerializeField]
		DialogTransistion nextGuessTransition;


		[SerializeField]
		Round round;

		[SerializeField]
		Players players;

		[SerializeField]
		PlayerIterator iterator;

		[SerializeField]
		Button replayButton;

		[SerializeField]
		Text playerNameField;

		[SerializeField]
		Image characterImage;

		[SerializeField]
		InputField phraseInput;

		[SerializeField]
		AudioSource audioSource;

		[SerializeField]
		Waveform waveform;

		void Awake(){
			phraseInput.onEndEdit.AddListener( OnEditEnd );
			replayButton.onClick.AddListener( ReplayClip );
		}

		void Update(){
			waveform.SetPlayhead( audioSource.time / audioSource.clip.length );
			
		}

        override public void Show(){
			waveform.gameObject.SetActive(true);
			if( players.NumPlayers()>1 && iterator.CurrentPlayer() == players.CurrentPlayer() ){
				iterator.NextPlayer();
			}
			base.Show();
			playerNameField.text = iterator.CurrentPlayer().name;
			characterImage.sprite = iterator.CurrentPlayer().character.charSprite;
			phraseInput.text = "";
			phraseInput.ActivateInputField();
		}

		override public void Hide()
		{
			base.Hide();
			waveform.gameObject.SetActive(false);

		}

		private void OnEditEnd(string guess)
        {
			if( guess == string.Empty){
				return;
			}
			round.guesses.Add( guess );
			NextDialog();
        }

		void ReplayClip()
		{
			round.playerRecording.PlayClipBackwards( audioSource );

		}

		void NextDialog()
		{
			Hide();



			if( iterator.NextPlayer() ){
				if( players.NumPlayers()>1 && iterator.CurrentPlayer() == players.CurrentPlayer() ){
					NextDialog();
					return;
				}
				nextGuessTransition.Show( this );
			}
			else {
				transistion.Show(nextDialog);
			}
		}
	}
}