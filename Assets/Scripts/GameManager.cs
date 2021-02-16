using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gmI; // SINGLETON INSTANCE
	public static UI_Container UI;
	public static Input_Container InputContainer;

	// Use Awake for initialization (setting up components etc.)
	private void Awake() {
		// SINGLETON
		if(gmI == null) {
			gmI = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
			return;
		}
		UI = GetComponent<UI_Container>();
		InputContainer = GetComponent<Input_Container>();
	}
}
