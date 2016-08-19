using UnityEngine;
using System.Collections;

public class RealBubbleManager : MonoBehaviour {

	public bool isbubble1;
	public bool isbubble2;
	public bool isbubble3;

	private Rigidbody2D rb2d;
	private Vector2 startPos;
	private Vector2 position;
	private Vector3 stageDimensions;
	private float speed;
	private float upspeed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		startPos = new Vector2 (stageDimensions.x * 1.3f, -8f);
		position = startPos;

		if (isbubble1) {
			speed = 0.08f;
			upspeed = 0.04f;
		} else if (isbubble2) {
			speed = 0.09f;
			upspeed = 0.05f;
		} else {
			speed = 0.1f;
			upspeed = 0.06f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (position.x > -14) {

			position.Set (position.x - (Time.timeScale * speed), position.y + Time.timeScale * upspeed);
			rb2d.MovePosition (position);

		} else {

			position.Set (startPos.x, startPos.y);

		}

		/*if (!bubbleflipped) {
			this.transform.FindChild ("RealBubble2").position = new Vector2(position.x - 0.5f, position.y);
			bubbleflipped = true;
		} else if (bubbleflipped) {
			this.transform.FindChild ("RealBubble2").position = new Vector2(position.x + 0.5f, position.y);
			bubbleflipped = false;
		}*/
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			position.Set (startPos.x, startPos.y);

		}
	} 
}
