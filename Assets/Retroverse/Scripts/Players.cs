using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Players/PlayerCollection")]
public class Players : ScriptableObject
{
    List<Player> players;
    int playerIndex = 0;
    public void Setup(int numPlayers) {
        players = new List<Player>();
        for (int i = 0; i < numPlayers; i++) {
            players.Add(new Player() {
                name = string.Format("Player {0}", i+1)
            });
        }

        
    }

    public int NumPlayers(){
        return players.Count;
    }

    public Player GetPlayerAt(int i)
    {
        return players[i];
    }

    public Player CurrentPlayer(){
        Debug.Log(playerIndex);
        return players[playerIndex];
    }


    public void FirstPlayer(){
        playerIndex = 0;

    }
    public bool NextPlayer(){
        playerIndex++;
        bool isComplete = false;
        if( playerIndex >= players.Count ){
            isComplete = true;
            playerIndex = 0;
        }

        return isComplete;

    }

}
