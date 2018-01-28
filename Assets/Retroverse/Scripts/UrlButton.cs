using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UrlButton : MonoBehaviour {

	[SerializeField]
	Button button;

	[SerializeField]
	TextAsset readmeUrl;

	// Use this for initialization
	void Awake () {
		button.onClick.AddListener( ()=>{
			Application.OpenURL( readmeUrl.text );
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
