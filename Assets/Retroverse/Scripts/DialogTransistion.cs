using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogTransistion : ScriptableObject 
{
	public event System.Action ShowBeginEvent;
	public event System.Action ShowCompleteEvent;
	public event System.Action HideBeginEvent;
	public event System.Action HideCompleteEvent;

	public void Show()
	{
		ShowBeginEvent.Invoke();
	}

	

}
