using UnityEngine;
using System.Collections;

public class NaveGDG : MonoBehaviour {

	Rigidbody2D rigidNave;
	public float naveSpeed;
	public GameObject myExplosion;
	float moveX;
	Transform myPosition;
	public GameObject myRay;
	public GameObject myCannon;
	Vector2 cannonPosition;



	// Use this for initialization
	void Start () {

		rigidNave = GetComponent<Rigidbody2D>();
		myPosition = GetComponent<Transform> ();


	
	}


	void Update(){
	
	
		if (Input.GetButtonDown ("Fire1")) {
			{
				cannonPosition = myCannon.GetComponent<Transform> ().position;
				GameObject rayShot = GameObject.FindGameObjectWithTag ("Weapon");

				if (rayShot ==  null) {
					Instantiate (myRay, cannonPosition, Quaternion.identity);
				}
			}		
		
		}
	}


	
	// Update is called once per frame
	void FixedUpdate () {

		moveX = Input.GetAxis("Horizontal");


		moveX = moveX*naveSpeed;

		Vector2 moveNave = new Vector2 (moveX*Time.deltaTime,0f);

		rigidNave.velocity = moveNave;
	
	}

	void OnCollisionEnter2D(Collision2D Coll){

		if (Coll.gameObject.tag == "Enemy" || Coll.gameObject.tag == "Player") {

			Instantiate (myExplosion, Coll.gameObject.transform.position, Quaternion.identity);
		}


	}
}		