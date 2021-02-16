﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Container", menuName = "Data Table/Dialogue Container")]
public class Dialogue_Container : ScriptableObject {

	public Char_Container[] speakers;
	public Sentence[] sentences;

	[System.Serializable]
	public struct Sentence {
		[TextArea(1, 7)]
		public string text;
		public int speakerIndex;
		public Char_Container.Expression expression;

		public UnityEngine.Events.UnityEvent events;
	}

	const string alphabet = "abcdefghijklmnopqrstuvwxyz"; // use this for seeking the audio files in dialogue
}
