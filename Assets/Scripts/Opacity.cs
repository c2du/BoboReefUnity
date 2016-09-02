using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Opacity : MonoBehaviour {

	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();

		Color c = image.color;
		c.a = 0.7f;
		image.color = c;
	}
}
