using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class Tanque : MonoBehaviour {

	public float speed;
	public Transform raio;
	public Transform canhao;

	public float fireRate;
	private float nextFire;

	Rigidbody2D myRigidBody;


	void Start(){

		nextFire = 0f;
		myRigidBody = GetComponent<Rigidbody2D>();


	}


	void Update ()
	{


		if (Input.GetButton("Fire1")){ 
			
	//			if (Time.time > nextFire)
	//			{
		//			nextFire = Time.time + fireRate;
		//			Instantiate(raio,canhao.position,Quaternion.identity);
	//			}

	//	else
				if(!raio){
					//nextFire = 0f;
					Instantiate(raio,canhao.position,Quaternion.identity);

				}

		}
	}




	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);

		myRigidBody.velocity = movement * speed;

	}

}