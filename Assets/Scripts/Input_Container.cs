using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Container : MonoBehaviour {
	public InputMaster input;

	// Use Awake for initialization (setting up components etc.)
	private void Awake() {
		input = new InputMaster();
		input.Enable();
		// subscribe functions to input events
		input.Exploration.Move.performed += ctx => moveAxis = ctx.ReadValue<Vector2>(); // lambda function for copying Move value to moveAxis
		input.Exploration.Move.canceled += ctx => moveAxis = Vector2.zero;

		input.Exploration.Interact.performed += ctx => Interact();
	}

	public void SetLockState(bool unlocked) {
		if (unlocked) input.Enable();
		else input.Disable();
	}

	#region INPUT VARIABLES
	public static Vector2 moveAxis;
	#endregion
	#region INPUT FUNCTIONS
	public static void Interact() {
		Debug.Log("Interact");
	}
	#endregion
}
