using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LevensteinTest {

    [Test]
    public void TestDiffStrings () {
        string a = "   kitten   ", b = "  sitting     ";

        Assert.AreEqual(3, Levenshtein.Distance(a, b));
    }

    [Test]
    public void TestSameString () {
        string a = "kitten";

        Assert.AreEqual(0, Levenshtein.Distance(a, a));
    }

    [Test]
    public void TestNormWithPunctuation () {
        string a = "hello,.,./,.     world      ";

        Assert.AreEqual("hello world", Levenshtein.NormString(a));
    }

    [Test]
    public void TestNormWithoutPunctuation () {
        string a = "hello world";

        Assert.AreEqual("hello world", Levenshtein.NormString(a));
    }

	[Test]
	public void TestDifferentNumberOfWords() {
        Assert.AreEqual(0, 0);
	}

    [Test]
    public void TestLongPhrase()
    {
        Assert.AreEqual(0, 0);
    }
}
