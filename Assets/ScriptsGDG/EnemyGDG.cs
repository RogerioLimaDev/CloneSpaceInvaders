using UnityEngine;
using System.Collections;

public class EnemyGDG : MonoBehaviour {

	Rigidbody2D rigidEnemy;
	public float myAlienSpeed;
	static float alienSpeed;
	GameObject myPlayer;
	Renderer mySprite;
	public GameObject myExplosion;


	// Use this for initialization
	void Start () {
		
		alienSpeed = myAlienSpeed;
		rigidEnemy = GetComponent<Rigidbody2D>();
		myPlayer = GameObject.FindGameObjectWithTag ("Player");

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector2 moveAlien = new Vector2 (alienSpeed*Time.deltaTime, 0f);
		rigidEnemy.velocity = moveAlien;

	}
		


	void OnCollisionEnter2D(Collision2D coll){


		if (coll.gameObject.tag == "Parede") {

				alienSpeed = -alienSpeed;		

		}


		if (coll.gameObject.tag == "Player") {

			myPlayer.SetActive(false);
			Instantiate (myExplosion, coll.gameObject.transform.position,Quaternion.identity);
			gameObject.SetActive (false);


		}

	}
}