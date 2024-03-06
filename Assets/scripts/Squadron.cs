using UnityEngine;
using System.Collections;
using System;

public class Squadron : MonoBehaviour 
{

	private float naveSpeed;
	private float invokeSpeed;
	ActionsController actionsController;
	Transform squadronTransform, leftLimit, rightLimit;

	void Awake()
	{
		actionsController = FindAnyObjectByType<ActionsController>();
	}

	void OnEnable()
	{
		actionsController.reverseSquadron += ReverseSquadron;
		actionsController.setSquadronSpeed += SetSquadronSpeed;
	}

    private void SetSquadronSpeed(float currentSpeed)
    {
		invokeSpeed = currentSpeed;
		CancelInvoke("MoveShip");
		InvokeRepeating("MoveShip", 0, invokeSpeed);
    }

    void OnDisable()
	{
		actionsController.reverseSquadron -= ReverseSquadron;
		actionsController.setSquadronSpeed -= SetSquadronSpeed;
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
		CancelInvoke("MoveShip");
		naveSpeed = 0.1f;
		invokeSpeed = 0.5f;
		squadronTransform = GetComponent<Transform>();
		InvokeRepeating("MoveShip", 0,invokeSpeed);
	}

	void MoveShip() 
	{
		squadronTransform.Translate(naveSpeed,0,0);
	}

}
