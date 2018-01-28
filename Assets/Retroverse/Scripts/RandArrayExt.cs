using System.Collections.Generic;
using UnityEngine;

static class RandArrayExt
{
	public static System.Random random = new System.Random();

	public static T[] Shuffle<T> (this T[] array)
	{
		if (array == null)
			return array;
		int l = (array.Length - 1);
		for (int i=0; i<l; i++) {
			T tmp = array [i];
			int r = Random.Range (i, array.Length);
			array [i] = array [r];
			array [r] = tmp;
		}
		return array;
	}
	
	public static IList<T> Shuffle<T> (this IList<T> array)
	{
		if (array == null)
			return null;
		int l = array.Count;
		for (int i=0; i<(l-1); i++) {
			T tmp = array [i];
			int r = Random.Range(i, l);
			array [i] = array [r];
			array [r] = tmp;
		}
		return array;
	}
	
	public static T PickRandom<T> (this T[] array)
	{
		int i = Random.Range(0, array.Length);
		return array [i];
	}
	
	public static T PickRandom<T>(this List<T> array)
	{
		int i = Random.Range(0, array.Count);
		return array [i];
	}
	
	public static T Shuffled<T>(this T[] array, int seed, int index)
	{
		int shuffleRange = array.Length;
		int output = index % shuffleRange;
		int cycleIndex = index / shuffleRange;
		
		while (output < shuffleRange)
		{
			output = (output + cycleIndex + seed) % shuffleRange;
			shuffleRange--;
		}
		
		return array[output];
	}
	
}