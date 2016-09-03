using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClickMain : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int scene)
	{
		loadingImage.SetActive (true);
		SceneManager.LoadScene (scene);
		Debug.Log ("Clicking start button");
	}
}
