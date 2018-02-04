using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions/QuestionCollection")]
public class Questions : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Question> questions;

    [System.NonSerialized]
    int questionIndex = 0;

    public Question CurrentQuestion(){
        return questions[questionIndex];
    }

    public bool NextQuestion(){
        questionIndex++;
        bool isComplete = false;
        if( questionIndex >=  questions.Count ){
            questionIndex = 0;
            isComplete = true;
        }
        return isComplete;
    }

    public void ShuffleQuestions(){
        
        questions.Shuffle();
    }

    void OnEnable(){
        Random.InitState( (int)(System.DateTime.Now.Ticks % int.MaxValue ) );
        ShuffleQuestions();
    }

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
    }

}
