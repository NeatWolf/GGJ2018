using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions/QuestionCollection")]
public class Questions : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Question> question;
    [System.NonSerialized]
    public int currentRound;

    public void OnAfterDeserialize()
    {
        currentRound = 1;
    }

    public void OnBeforeSerialize()
    {
    }

}
