using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gmI; // SINGLETON INSTANCE

	// Use Awake for initialization (setting up components etc.)
	private void Awake() {
		// SINGLETON
		if(gmI == null) {
			gmI = this;
			DontDestroyOnLoad(gmI);
		} else {
			Destroy(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}
