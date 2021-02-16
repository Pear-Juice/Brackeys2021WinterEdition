using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Dialogue Container", menuName = "Data Table/Dialogue Container")]
public class Dialogue_Container : ScriptableObject {

	public Char_Container[] speakers;
	public Sentence[] sentences;

	public float speechLetterInterval = .2f;

	[System.Serializable]
	public struct Sentence {
		[TextArea(1, 7)]
		public string text;
		public int speakerIndex;
		public Char_Container.Expression expression;

		public UnityEngine.Events.UnityEvent events;
	}

	const string alphabet = "abcdefghijklmnopqrstuvwxyz"; // use this for seeking the audio files in dialogue

	public IEnumerator SpeakSentence(Char_Container character, string sentence, float interval) {
		for(int i = 0; i < sentence.Length; i++) {
			GameManager.UI.dialogue_Text.text = sentence.Substring(0, i + 1);
			string letter = new string(sentence[i], 1).ToLower();
			if (!alphabet.Contains(letter)) continue;
			AudioClip clip = character.dialogueSounds[alphabet.IndexOf(letter)];
			if (!clip) {
				Debug.LogError("Could not find " + character.charName + "'s dialogue sound: " + sentence);
				continue;
			}
			AudioManager.Play(clip);
			yield return new WaitForSeconds(interval);
		}
	}
}
