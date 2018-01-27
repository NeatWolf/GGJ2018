using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "Questions/Question")]
public class Question : ScriptableObject
{
    public VideoClip videoClipForward;
    public VideoClip videoClipReverse;
    public string answer;
    public int difficulty;
    
}
