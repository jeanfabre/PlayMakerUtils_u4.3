// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.
// THIS CONTENT IS AUTOMATICALLY GENERATED. __PLAYMAKER_EVENT_PROXY__
// this script was generated by the 'PlayMaker Event Proxy Wizard'. You can edit this script directly now, but prefer using the wizard if you are not sure.

using UnityEngine;
using HutongGames.PlayMaker.Ecosystem.Utils;

namespace com.yourdomain
{
	public class MyAnimationEventProxy : PlayMakerEventProxy {

		[Button("MyAnimationEvent","Test : MyAnimationEvent")] public bool _;
		public void MyAnimationEvent()
		{
			if (debug || !Application.isPlaying)
			{
				Debug.Log("MyAnimationEventProxy : MyAnimationEvent()");
			}
			base.SendPlayMakerEvent();
		}
	}
}