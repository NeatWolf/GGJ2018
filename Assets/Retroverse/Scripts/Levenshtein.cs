using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Levenshtein : MonoBehaviour {

    public static int Distance (string _a, string _b) {
        string a = NormString(_a), b = NormString(_b);
        return Distance(a, b, a.Length, b.Length);
    }

    private static int Distance (string a, string b, int lenA, int lenB)
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

    public static string NormString (string a) {
        Regex rgx_NonAlphanum = new Regex("[^a-zA-Z0-9 -]");
        Regex rgx_MultiSpace = new Regex("[ ]{2,}");

        string norm = rgx_NonAlphanum.Replace(a, "");
        norm = rgx_MultiSpace.Replace(norm, " ");

        return norm.Trim();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
