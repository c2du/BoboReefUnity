using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour {

	public AudioClip newMusic;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded(int scene)
	{
		if (scene == 0) 
		{
			source.clip = newMusic;
			source.Play ();
		}
	}
}
