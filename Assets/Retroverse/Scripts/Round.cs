using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject, ISerializationCallbackReceiver {
	public int roundNum = 1;
	public List<string> guesses;
	public ClipRecording playerRecording;

    public void OnAfterDeserialize()
    {
        roundNum = 1;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
