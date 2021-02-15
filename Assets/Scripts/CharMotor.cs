using UnityEngine;

public class CharMotor : MonoBehaviour {
	public CharStats stats;



	private Vector2 velocity = Vector2.zero;

	const float acceleration = 1.0f;
	const float deceleration = 1.0f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		velocity -= Vector2.one * deceleration * Time.deltaTime; // to be implemented later

		transform.position += (Vector3)Input_Container.moveAxis * stats.speed * Time.deltaTime;
	}
}
