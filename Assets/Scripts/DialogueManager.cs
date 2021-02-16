using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

	Queue<Dialogue_Container.Sentence> sentences = new Queue<Dialogue_Container.Sentence>();
	Dialogue_Container dialogueContainer;

	public void StartDialogue(Dialogue_Container container) {
		sentences.Clear();

		GameManager.InputContainer.SetLockState(false);

		GameManager.UI.dialogueRoot.gameObject.SetActive(true);
		dialogueContainer = container;
		foreach (Dialogue_Container.Sentence sentence in container.sentences) {
			sentences.Enqueue(sentence);
		}
		AdvanceDialogue();
	}

	Coroutine speakRoutine;

	public void AdvanceDialogue() {
		if(sentences.Count == 0) {
			GameManager.UI.dialogueRoot.gameObject.SetActive(false);
			GameManager.InputContainer.SetLockState(true);
			return;
		}

		Dialogue_Container.Sentence sentence = sentences.Dequeue();

		GameManager.UI.dialogue_Char1_IMG.sprite = dialogueContainer.speakers[sentence.speakerIndex].expressions[(int)sentence.expression];
		GameManager.UI.dialogue_Char1_Name.text = dialogueContainer.speakers[sentence.speakerIndex].charName;
		//GameManager.UI.dialogue_Text.text = sentence.text;

		sentence.events.Invoke();

		if(speakRoutine != null) StopCoroutine(speakRoutine);
		speakRoutine = StartCoroutine(dialogueContainer.SpeakSentence(dialogueContainer.speakers[sentence.speakerIndex], sentence.text, dialogueContainer.speechLetterInterval));
	}
}
