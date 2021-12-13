using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This character movement input class is an example of how to get input from a keyboard to control the character;
    public class CharacterKeyboardInput : CharacterInput
    {
		public string horizontalInputAxis = "Horizontal";
		public string verticalInputAxis = "Vertical";
		public string jumpKey = "Jump";

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;
		private bool active;

		public override float GetHorizontalMovementInput()
		{
			if(useRawInput)
				return Input.GetAxisRaw(horizontalInputAxis);
			else
				return Input.GetAxis(horizontalInputAxis);
		}

		public override float GetVerticalMovementInput()
		{
			if(useRawInput)
				return Input.GetAxisRaw(verticalInputAxis);
			else
				return Input.GetAxis(verticalInputAxis);
		}

		public override bool IsJumpKeyPressed()
		{
			if (active)
			{
				if (MngrScript.Instance.getCurrentState() == "Menu" || MngrScript.Instance.getCurrentState() == "SplashScreen")
				{
					return Input.GetAxis(jumpKey) != 0;
				}
				else
				{
					active = false;
					return false;
				}
			}
			else
			{
				return false;
			}
		}
    }
}
