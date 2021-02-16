using UnityEngine;

public class CharMotor : MonoBehaviour {
	public CharStats stats;
	public PhysicsConfig_Container physCfg;

	private Vector2 velocity;

	const float acceleration = 9.0f;
	const float deceleration = 6.0f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		velocity -= velocity * deceleration * Time.deltaTime;

		Vector2 moveV_target = (Input_Container.moveAxis * stats.speed) - velocity; // amount of force to add to maintain ideal velocity
		velocity += moveV_target * acceleration * Time.deltaTime;

		Vector2 processedVelocity = velocity * Time.deltaTime;
		Vector3 targetPosition = transform.position + (Vector3)processedVelocity;

		RaycastHit2D[] hits = new RaycastHit2D[3];
		int hitCount = Physics2D.CircleCast(transform.position, physCfg.collisionRadius, velocity.normalized, physCfg.collisionFilter, hits, processedVelocity.magnitude);
		if (hitCount > 0) {
			targetPosition = hits[0].point + hits[0].normal * physCfg.collisionRadius;
		}

		transform.position = targetPosition;
	}

	private void OnDrawGizmosSelected() {
		if (physCfg == null) return;
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, physCfg.collisionRadius);
	}
}
