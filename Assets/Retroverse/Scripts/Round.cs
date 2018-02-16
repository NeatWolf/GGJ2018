using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject, ISerializationCallbackReceiver {
	public int roundNum = 1;

    [System.NonSerialized]
	public List<string> guesses;
	public ClipRecording playerRecording;

    public void OnEnable()
    {
        guesses = new List<string>();
    }

    public void OnAfterDeserialize()
    {
        roundNum = 1;
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void Reset()
    {
        guesses.Clear();
        roundNum = 1;
    }
}
