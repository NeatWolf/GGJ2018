using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject {
	public int roundNum = 1;
	public List<string> guesses;
	public ClipRecording playerRecording;


}
