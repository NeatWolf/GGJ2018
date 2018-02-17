using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Profiling;

public class Levenshtein {

    public static int Distance (string _a, string _b) {
        Profiler.BeginSample("Distance");
        string a = NormString(_a), b = NormString(_b);
        int distance = Distance(ref a, ref b, a.Length, b.Length);
        Profiler.EndSample();
        return distance;
    }

    private static int Distance (ref string a, ref string b, int lenA, int lenB)
    {
        int cost;

        if (lenA == 0) { return lenB; }
        if (lenB == 0) { return lenA; }

        if (a[lenA-1] == b[lenB-1]) {
            cost = 0;
        } else {
            cost = 1;
        }

        return Mathf.Min(Distance(ref a, ref b, lenA - 1, lenB) + 1,
                         Distance(ref a, ref b, lenA, lenB-1) + 1,
                         Distance(ref a, ref b, lenA - 1, lenB - 1) + cost);
    }

    public static string NormString (string a) {
        Profiler.BeginSample("NormString");
        Regex rgx_NonAlphanum = new Regex("[^a-zA-Z0-9 -]");
        Regex rgx_MultiSpace = new Regex("[ ]{2,}");

        string norm = rgx_NonAlphanum.Replace(a, "");
        norm = rgx_MultiSpace.Replace(norm, " ");
        var output = norm.Trim();
        Profiler.EndSample();
        return  output;
    }
}
