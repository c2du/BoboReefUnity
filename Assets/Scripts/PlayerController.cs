﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public bool dead;
	public GameObject bg;

	private Rigidbody2D rb2d;
	private Touch touch;
	private int count;
	private SpriteRenderer fsr;
	//private ObjectPool objectPool;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		setCountText ();
		dead = false;
		//objectPool = GameObject.Find ("GameManager").GetComponent<ObjectPool> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Fish")) {
			//other.gameObject.SetActive (false);

			//other.gameObject.GetComponent<MoveManager> ().changeSpeed ();
			//fsr = other.gameObject.GetComponent<SpriteRenderer> ();
			//fsr.flipX = false;

			//gameManager.decreaseFishCount ();
			//objectPool.PoolObject (other.gameObject);
			//Destroy (other.gameObject);
			//gameManager.numFish -= 1;

			count = count + 1;
			setCountText ();
		}
	}

	void setCountText () {
		countText.text = "Friends: " + count.ToString ();
	}

	void FixedUpdate()
	{
		//Debug.Log (Input.GetAxis("Vertical"));
		//float move = Input.GetAxis ("Vertical");

		//if (move != 0) {

		if (GameManager.paused == true) {
			PauseGame ();
		} else {

			if (Input.touchCount > 0) {
				rb2d.AddForce (new Vector2 (0f, 5.0f));
			}
			//Debug.Log (Input.GetMouseButton (0).ToString ());
			if (Input.GetMouseButton (0)) {
				rb2d.AddForce (new Vector2 (0f, 14.0f));
			}

			if (dead) {
				spinCorgi ();
			}
		}
	}

	public void spinCorgi() {
		transform.Rotate (Vector3.forward * -30);
		rb2d.AddForce (new Vector2 (0f, 20f));
		bg.SetActive (false);
	}

	public void PauseGame() {
		this.gameObject.GetComponent<Animation> ().Stop ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	public void ResumeGame() {
		this.gameObject.GetComponent<Animation> ().Play ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	/*void OnApplicationFocus(bool focusStatus){
		isPaused = focusStatus;
	}*/
}
