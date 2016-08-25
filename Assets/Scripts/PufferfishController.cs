using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PufferfishController : MonoBehaviour {

	private GameObject corgi;

	private GameObject canvas;
	private GameObject gm;
	//private GameObject bg;

	public float speed;
	private Rigidbody2D rb2d;
	private Vector2 position;
	//private ObjectPool objectPool;
	private Vector3 stageDimensions;
	//private float pausespeed;
	private BoxCollider2D bc2d;
	private bool firstCollision;

	private Animator animator;
	private CircleCollider2D cc2d;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		bc2d = GetComponent<BoxCollider2D> ();
		firstCollision = false;
		corgi = GameObject.Find ("A_corgi");

		canvas = GameObject.Find ("Canvas");
		gm = GameObject.Find ("GameManager");
		//bg = GameObject.Find ("background");

		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

		rb2d = GetComponent<Rigidbody2D> ();
		position = new Vector2 (10f, Random.Range (-stageDimensions.y, stageDimensions.y));
		speed = Random.Range(0.03f, 0.09f);
		//objectPool = GameObject.Find ("GameManager").GetComponent<ObjectPool> ();

		//StartCoroutine(Puff());
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.paused == true) {
			PauseGame ();
		} else {
			ResumeGame ();
		}

		/*if (PlayerController.bubblecount < 1) {
			canvas.GetComponent<LoadOnClick> ().DisplayGameOver ();
			GameObject.Find("Corgi_Streamline").GetComponent<PlayerController>().spinCorgi ();
			GameObject.Find("Corgi_Streamline").GetComponent<PlayerController>().dead = true;
			gm.GetComponent<GameManager> ().GameOver ();
			//bg.GetComponent<Scroll> ().speed = 0;
		}*/
			

		position.Set (position.x - Time.timeScale*(speed), position.y);
		rb2d.MovePosition (position);
		//animator = GetComponent<Animator> ();
		//Debug.Log ("Pufferfish is Alive");
	}

	IEnumerator Puff(){
	
		yield return new WaitForSeconds (0.3f);
		animator.SetBool ("puff", true);
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("Entering onCollisionEnter");
		if (other.gameObject.CompareTag ("Player")) {
			if (firstCollision == false) {
				Debug.Log ("First Collision Detected");
				firstCollision = true;
				animator.SetBool ("puff", true);
				bc2d.enabled = false;
			} else {
				if (canvas.GetComponent<LoadOnClick> ().hasAir ()) {
					canvas.GetComponent<LoadOnClick> ().loseAllAir ();
					corgi.GetComponent<PlayerController> ().animator.SetBool ("air", false);
				} else {
					Debug.Log ("PUFFERFISH KILLS CORGI");
					canvas.GetComponent<LoadOnClick> ().DisplayGameOver ();
					other.GetComponent<PlayerController> ().spinCorgi ();
					other.GetComponent<PlayerController> ().dead = true;
					gm.GetComponent<GameManager> ().GameOver ();
				}
				//bg.GetComponent<Scroll> ().speed = 0;
			}
		}
	
		if (other.gameObject.CompareTag ("BarrierEnd")) {
			Destroy (this.gameObject);
		}
		
	}

	public void PauseGame() {
		Time.timeScale = 0f;
		//this.gameObject.GetComponent<Animation> ().Stop ();
	}

	public void ResumeGame() {
		//speed = pausespeed;
		Time.timeScale = 1f;
	}
}
