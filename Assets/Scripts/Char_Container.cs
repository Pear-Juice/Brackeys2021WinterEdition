using UnityEngine;

[CreateAssetMenu(fileName = "New Character Table", menuName = "Data Table/Character Table")]
public class Char_Container : ScriptableObject {
	public enum Expression { Happy = 0, Sad = 1, Angry = 2, Scared = 3 }

	public string charName = "John Smith";

	public CharStats stats;

	[Header("Dialogue Sprites")]
	public Sprite[] expressions;

	public AudioClip[] dialogueSounds;
}
