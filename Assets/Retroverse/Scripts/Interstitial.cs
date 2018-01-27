using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class Interstitial : MonoBehaviour {



	[SerializeField]
	DialogTransistion dialog;

	[SerializeField]
	TimelineAsset assetToPlay;

	PlayableDirector playableDirector;

	public void Awake()
	{
		dialog.ShowBeginEvent += OnShowBegin; 	
	}

    private void OnShowBegin()
    {
		playableDirector.Play();
    }
}
