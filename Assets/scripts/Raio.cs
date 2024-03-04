using UnityEngine;
using System.Collections;


public class Raio : MonoBehaviour {

	public float raioSpeed = 10f;
	Collider2D tanque;
	Collider2D raio;
	public Transform explosaoNave;
	int scoreValue;
	public int enemyValue;
	Score scoreScript ;

	void Start(){

		tanque = GameObject.Find("Tanque").GetComponent<Collider2D>();
		scoreScript = GameObject.Find("Score").GetComponent<Score>();
		raio = GetComponentInParent<Collider2D>();
	}


	void FixedUpdate ()
	{

		Physics2D.IgnoreCollision(raio,tanque);

		Vector2 movement = new Vector2 (0.0f, raioSpeed);

		Rigidbody2D myRigidBody = GetComponent<Rigidbody2D>();

		myRigidBody.velocity = movement;
	}



	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Boundary"){
			Destroy(gameObject);
		}

		else

		if (coll.gameObject.tag == "Enemy"){


				Destroy(coll.gameObject);
				Destroy(gameObject);
				Instantiate(explosaoNave,coll.gameObject.transform.position,Quaternion.identity);
				scoreScript.SetScore();

			}
	}
		
}
