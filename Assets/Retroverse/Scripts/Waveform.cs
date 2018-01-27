using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveform : MonoBehaviour {

	ClipRecording clipRecording;
	
	Material currentMat;

	public void GetWaveform(AudioClip clip){
		Texture2D texture = new Texture2D(128, 1, TextureFormat.RGFloat, false);
		texture.wrapMode = TextureWrapMode.Clamp;

		var size = clip.samples * clip.channels;
		Debug.Log(size);

		var samples = new float[size];
		clip.GetData(samples, 0);
		// clear the texture
		Color32 resetColor = new Color32(0, 0, 0, 0);
		Color32[] resetColorArray = texture.GetPixels32();

		for (int i=0; i<resetColorArray.Length; i++) {
			resetColorArray[i] = resetColor;
		}

		int sampleWidth = size/texture.width;
		Debug.LogFormat("sampleWidth: {0}", sampleWidth);
		for (int i=0; i<texture.width; i++) {
			float maxSample = 0, minSample = 1;
			
			for (var j=0; j<sampleWidth; j++) {
				int index = j+i*sampleWidth;

				if (samples[index] > maxSample)
					maxSample = samples[index];

				if (samples[index] < minSample)
					minSample = samples[index];
			}
			texture.SetPixel(i, 0, new Color(maxSample, minSample, 0));
		}
		// upload to the graphics card
		texture.Apply();

		currentMat.SetTexture("_MainTex", texture);
		
	}

	public void SetPlayhead (float time) {
		currentMat.SetFloat("_Timer", time);
	}

	void Awake () {
		currentMat = GetComponent<MeshRenderer>().sharedMaterial;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
