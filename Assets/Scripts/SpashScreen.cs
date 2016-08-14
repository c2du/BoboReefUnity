using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpashScreen : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		float fadeTime = GameObject.Find ("Fade").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (1);

		//yield return new WaitForSeconds (2f);
		//SceneManager.LoadScene (1);
	}
}
