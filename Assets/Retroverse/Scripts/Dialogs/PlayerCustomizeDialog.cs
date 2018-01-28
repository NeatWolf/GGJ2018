using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2018 {
	public class PlayerCustomizeDialog : Dialog {

		[SerializeField]
		private CharacterInfo[] characters;

		[SerializeField]
		private Image charImg;
		[SerializeField]
		private Text charName;

		[SerializeField]
		private Text playerNameTitle;

		[SerializeField]
		private InputField playerNameInput;

		[SerializeField]
		private Players players;

		[SerializeField]
		private DialogTransistion transition;

		[SerializeField]
		private Dialog nextDialog;

		[SerializeField]
		PlayerIterator playerIterator;

		private int charIndex = 0;

		public void ResetChar () {
			charIndex = 0;
			UpdateChar();
		}

		public void NextChar () {
			if (charIndex >= characters.Length-1) {
				charIndex = 0;
			} else {
				charIndex += 1;
			}

			UpdateChar();
		}

		public void PrevChar () {
			if (charIndex <= 0) {
				charIndex = characters.Length-1;
			} else {
				charIndex -= 1;
			}

			UpdateChar();
		}

		private void UpdateChar () {
			charImg.sprite = characters[charIndex].charSprite;
			charName.text = characters[charIndex].charName;
		}

		public void NextPlayer () {
			players.CurrentPlayer().name = playerNameInput.text.PadRight('_');
			players.CurrentPlayer().character = characters[charIndex];

			bool noMorePlayers = players.NextPlayer();

			playerNameTitle.text = players.CurrentPlayer().name;

			playerNameInput.text = "";

			ResetChar();

			if (noMorePlayers) {
				Hide();
				transition.Show( nextDialog );
			}
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}