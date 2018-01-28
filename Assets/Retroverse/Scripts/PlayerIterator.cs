using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerIterator : ScriptableObject, ISerializationCallbackReceiver {

	public Players players;

	int playerIndex;

	public bool NextPlayer(){
		playerIndex++;
		bool notAtEnd = true;
		if( playerIndex >= players.NumPlayers() ){
			playerIndex = 0;
			notAtEnd = false;
		}
		
		return notAtEnd;
	}

	public Player CurrentPlayer(){
		return players.GetPlayerAt(playerIndex);
	}

    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        playerIndex = 0;
    }
}
