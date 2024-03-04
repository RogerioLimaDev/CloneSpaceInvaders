using UnityEngine;
using System.Collections;

public class RaioGDG : MonoBehaviour {


	public float raySpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, raySpeed);

	
	}


	void OnCollisionEnter2D(Collision2D Coll){
	
		if (Coll.gameObject.tag == "Enemy" || Coll.gameObject.tag == "Floor") {
		
			Destroy (gameObject);
		
		
		}
	
	
	
	}
}
