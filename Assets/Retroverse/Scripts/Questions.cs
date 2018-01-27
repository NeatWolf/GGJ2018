using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions/QuestionCollection")]
public class Questions : ScriptableObject
{
    public List<Question> question;
}
