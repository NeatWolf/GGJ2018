using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levenshtein : MonoBehaviour {

    public static int Distance (string a, string b, int lenA, int lenB)
    {
        int cost;

        if (lenA == 0) { return lenB; }
        if (lenB == 0) { return lenA; }

        if (a[lenA-1] == b[lenB-1]) {
            cost = 0;
        } else {
            cost = 1;
        }

        return Mathf.Min(Distance(a, b, lenA - 1, lenB) + 1,
                         Distance(a, b, lenA, lenB-1) + 1,
                         Distance(a, b, lenA - 1, lenB - 1) + cost);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
