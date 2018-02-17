using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundText : MonoBehaviour {

	[SerializeField]
	Text roundText;

	[SerializeField]
	Round round;

	[SerializeField]
	GameState gameState;

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
	public void OnEnable(){
		if( players.CurrentPlayer() == null ){
			return;
		}
		roundText.text = string.Format( formatStr, round.roundNum );
		characterImage.sprite = players.CurrentPlayer().character.charSprite;
		playerNameField.text = players.CurrentPlayer().name;
	}
}
