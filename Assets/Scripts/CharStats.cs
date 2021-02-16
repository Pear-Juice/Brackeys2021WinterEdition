using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Table", menuName = "Data Table/Character Stat Table")]
public class CharStats : ScriptableObject {

	public int hp = 1;

	public int atk = 1;
	public int def = 1;
	public int speed = 1;
}
