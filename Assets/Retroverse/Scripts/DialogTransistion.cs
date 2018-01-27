using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018 {

	[CreateAssetMenu]
	public class DialogTransistion : ScriptableObject 
	{
		public event System.Action<Dialog> ShowBeginEvent;
		public event System.Action ShowEndEvent;

		public void Show(Dialog dialog)
		{
			
			ShowBeginEvent.Invoke(dialog);
		}

        public void ShowComplete()
        {
            if( ShowEndEvent != null ){
				ShowEndEvent.Invoke();
			}
        }
    }

}