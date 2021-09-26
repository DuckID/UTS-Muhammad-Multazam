using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

	public int force;
	Rigidbody2D rigid;
	public int score;
	public int health;
	public Text countText;
	public Text healthText;
	GameObject losePanel;
	GameObject winPanel;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		Vector2 arah = new Vector2 (0, -2).normalized;
		rigid.AddForce (arah * force);
		score = 0;
		health = 3;
		SetCountText ();
		SetCountHealth ();
		losePanel = GameObject.Find ("LosePanel");
		winPanel = GameObject.Find ("WinPanel");
		losePanel.SetActive (false);
		winPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 100) {
			winPanel.SetActive (true);
			Destroy (gameObject);
		}
	}

	void ResetBall ()
	{
		transform.localPosition = new Vector2 (0, 0);
		rigid.velocity = new Vector2 (0, 0);
	}

	private void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.gameObject.name == "Paddle")
		{
			float sudut = (coll.transform.position.x - transform.position.x) * 5f;
			Vector2 arah = new Vector2(-sudut, rigid.velocity.y).normalized;
			rigid.velocity = new Vector2(0, 0);
			rigid.AddForce(arah * force * 2);
			}

		if (coll.gameObject.CompareTag ("Pick Up Ungu")) {
			coll.gameObject.SetActive (false);
			score = score + 1;
			SetCountText ();
		}

		if (coll.gameObject.CompareTag ("Pick Up Hijau")) {
			coll.gameObject.SetActive (false);
			score = score + 5;
			SetCountText ();
		}

		if (coll.gameObject.CompareTag ("Pick Up Merah")) {
			coll.gameObject.SetActive (false);
			score = score + 10;
			SetCountText ();
		}

		if (coll.gameObject.CompareTag ("Pick Up Kuning")) {
			coll.gameObject.SetActive (false);
			score = score + 20;
			SetCountText ();
		}

		if (coll.gameObject.name == "DeadZone") {
			ResetBall ();
			health = health -1;
			if (health == 0) {
				losePanel.SetActive (true);
				Destroy (gameObject);
			}
			SetCountHealth ();
			Vector2 arah = new Vector2 (0, -2).normalized;
			rigid.AddForce (arah * force);
		}
	}
	void SetCountText() {
		countText.text = score.ToString ();
	}
	void SetCountHealth() {
		healthText.text = "Health: " + health.ToString ();
	}
}