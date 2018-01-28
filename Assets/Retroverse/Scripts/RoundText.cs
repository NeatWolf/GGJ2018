﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundText : MonoBehaviour {

	[SerializeField]
	Text roundText;

	[SerializeField]
	Questions questions;

	[SerializeField]
	Players players;

	[SerializeField]
	Text playerNameField;

	[SerializeField]
	Image characterImage;

	string formatStr;
	// Use this for initialization
	void Awake () {
		formatStr = roundText.text;
	}
	
	// Update is called once per frame
	void OnEnable(){
		roundText.text = string.Format( formatStr, questions.currentRound );
		characterImage.sprite = players.CurrentPlayer().character.charSprite;
		playerNameField.text = players.CurrentPlayer().name;
	}
}
