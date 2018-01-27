using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPlayersDialog : MonoBehaviour {

	[SerializeField]
	Players players;

	[SerializeField]
	DialogTransistion transition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNumPlayers(int i){
		players.Setup(i);

		transition.Show();
	}
}
