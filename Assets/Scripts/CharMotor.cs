using UnityEngine;

public class CharMotor : MonoBehaviour {
	public CharStats stats;



	private Vector2 velocity;

	const float acceleration = 9.0f;
	const float deceleration = 6.0f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		velocity -= velocity * deceleration * Time.deltaTime;

		Vector2 moveV_target = (Input_Container.moveAxis * stats.speed) - velocity;
		velocity += moveV_target * acceleration * Time.deltaTime;

		transform.position += (Vector3)velocity * Time.deltaTime;

		Debug.Log(velocity);
	}
}
