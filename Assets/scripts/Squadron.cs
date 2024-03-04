using UnityEngine;
using System.Collections;
using System;

public class Squadron : MonoBehaviour 
{

	[SerializeField] private float naveSpeed;
	ActionsController actionsController;
	Transform squadronTransform, leftLimit, rightLimit;

	void Awake()
	{
		actionsController = FindAnyObjectByType<ActionsController>();
	}

	void OnEnable()
	{
		actionsController.reverseSquadron += ReverseSquadron;
	}

	void OnDisable()
	{
		actionsController.reverseSquadron -= ReverseSquadron;
	}

    private void ReverseSquadron()
    {
		// Debug.Log("REVERSE SQUADRON!!!!");
		naveSpeed *= -1;
		Invoke("MoveSquadDown", 0.3f);
    }

	private void MoveSquadDown() 
	{
		Vector2 squadPosition = new Vector2();
		squadPosition.x = squadronTransform.position.x;
		squadPosition.y = squadronTransform.position.y;
		squadPosition.y = squadPosition.y -= 0.05f;
		squadronTransform.position = squadPosition;
		CancelInvoke("MoveSquadDown");
	}

    void Start ()
	{
		squadronTransform = GetComponent<Transform>();
		InvokeRepeating("MoveShip", 0, 0.5f);
	}

	void MoveShip() 
	{
		squadronTransform.Translate(naveSpeed,0,0);
	}

}
