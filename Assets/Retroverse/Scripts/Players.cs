using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Players/PlayerCollection")]
public class Players : ScriptableObject
{
    List<Player> players;

    public void Setup(int numPlayers) {
        players = new List<Player>(numPlayers);
        for (int i = 0; i < players.Count; i++) {
            players[i] = new Player() {
                name = string.Format("Player {0}", i)
            };
        }

        
    }



}
