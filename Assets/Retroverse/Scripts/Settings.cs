using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class Settings : ScriptableObject 
{
	public Color32[] palette;
	public int[] numberOfRoundsForPlayerCount;
	public int numberOfTries;
	public string triesRemainingText = "Tries Left {0}";
	public int speakerPointBonus = 20;
	public Color speakerPanelColor;
}
