using UnityEngine;

public class AudioManager : MonoBehaviour {
	static int poolIndex = 0;
	static AudioSource[] sources;

	public int audioPoolSize;
	public AudioSource audioPrefab;

	// Use Awake for initialization (setting up components etc.)
	private void Awake() {
		sources = new AudioSource[audioPoolSize];

		Transform root = new GameObject("Audio Pool").transform;
		root.SetParent(transform);

		for(int i = 0; i < audioPoolSize; i++) {
			sources[i] = Instantiate(audioPrefab, root);
		}
	}

	public static void Play(AudioClip audioClip) {
		sources[poolIndex].gameObject.SetActive(true);
		sources[poolIndex].PlayOneShot(audioClip);

		poolIndex++;
	}
}
