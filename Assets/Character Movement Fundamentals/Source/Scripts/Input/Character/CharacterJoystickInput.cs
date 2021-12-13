using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This character movement input class is an example of how to get input from a gamepad/joystick to control the character;
	//It comes with a dead zone threshold setting to bypass any unwanted joystick "jitter";
	public class CharacterJoystickInput : CharacterInput {

		public string horizontalInputAxis = "Horizontal";
		public string verticalInputAxis = "Vertical";
		public string jumpKey = "Jump";

		//If this is enabled, Unity's internal input smoothing is bypassed;
		public bool useRawInput = true;

		//If any input falls below this value, it is set to '0';
        //Use this to prevent any unwanted small movements of the joysticks ("jitter");
		public float deadZoneThreshold = 0.2f;
		private bool active = true;

		public override float GetHorizontalMovementInput()
		{
			float _horizontalInput;

			if(useRawInput)
				_horizontalInput = Input.GetAxisRaw(horizontalInputAxis);
			else
				_horizontalInput = Input.GetAxis(horizontalInputAxis);

			//Set any input values below threshold to '0';
			if(Mathf.Abs(_horizontalInput) < deadZoneThreshold)
				_horizontalInput = 0f;

			return _horizontalInput;
		}

		public override float GetVerticalMovementInput()
		{
			float _verticalInput;

			if(useRawInput)
				_verticalInput = Input.GetAxisRaw(verticalInputAxis);
			else
				_verticalInput = Input.GetAxis(verticalInputAxis);

			//Set any input values below threshold to '0';
			if(Mathf.Abs(_verticalInput) < deadZoneThreshold)
				_verticalInput = 0f;

			return _verticalInput;
		}

		public override bool IsJumpKeyPressed()
		{
			//print(Input.GetAxis(jumpKey));
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

			//return false;
		}

	}
}
