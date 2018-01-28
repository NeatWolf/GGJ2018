using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {
	public Image charImg;
	public Text playerName, scoreThisRound, totalScore;
	public Image background;

	private void Awake () {
		background = GetComponent<Image>();
	}
}
