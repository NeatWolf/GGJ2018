using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveform : MonoBehaviour {

	Material currentMat;

	public void GetWaveform(AudioClip clip){
		Texture2D texture = new Texture2D(256, 1, TextureFormat.RGFloat, false);

		var size = clip.samples * clip.channels;
		var samples = new float[size];
		clip.GetData(samples, 0);
		// clear the texture
		Color32 resetColor = new Color32(0, 0, 0, 0);
		Color32[] resetColorArray = texture.GetPixels32();

		for (int i=0; i<resetColorArray.Length; i++) {
			resetColorArray[i] = resetColor;
		}

		// draw the waveform
		for (int i = 0; i < size; i++){
			texture.SetPixel(texture.width * i / size, 0, new Color(1 / (samples[i]), 0, 0));
		}
		// upload to the graphics card
		texture.Apply();

		currentMat.SetTexture("_MainTex", texture);
	}

	void Awake () {
		currentMat = GetComponent<MeshRenderer>().material;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
