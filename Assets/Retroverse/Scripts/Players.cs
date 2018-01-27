using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Players/PlayerCollection")]
public class Players : ScriptableObject
{
    List<Player> players;
    int playerIndex = 0;
    public void Setup(int numPlayers) {
        players = new List<Player>(numPlayers);
        for (int i = 0; i < players.Count; i++) {
            players[i] = new Player() {
                name = string.Format("Player {0}", i)
            };
        }

        
    }

    public Player CurrentPlayer(){
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
