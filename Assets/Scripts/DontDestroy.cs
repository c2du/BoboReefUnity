using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Awake is called before Start ()
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

}
