using UnityEngine;

[CreateAssetMenu(fileName = "New Character Table", menuName = "Data Table/Character Table")]
public class CharStats : ScriptableObject {
	public string charName = "John Smith";

	public int hp = 1;

	public int atk = 1;
	public int def = 1;
	public int speed = 1;
}
