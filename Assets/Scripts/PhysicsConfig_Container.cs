using UnityEngine;

[CreateAssetMenu(fileName = "New Physics Config", menuName = "Data Table/Physics Config")]
public class PhysicsConfig_Container : ScriptableObject {
	public float collisionRadius = 1.0f;
	public ContactFilter2D collisionFilter;
}
