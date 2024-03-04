using UnityEngine;
using System.Collections;
// using TMPro;

public class Score : MonoBehaviour {


	// TMP_text score;
	int scoreValue;
	public int enemyValue;


	void Start(){

		PlayerPrefs.SetInt("Score",0);
		scoreValue = 0;
		// score = GetComponentInParent<Text>();

	}


	// Update is called once per frame
	void Update () {

		// score.text = PlayerPrefs.GetInt("Score").ToString();
	
	}

	public void SetScore (){


		scoreValue = scoreValue + enemyValue;
		PlayerPrefs.SetInt("Score",scoreValue);


	}
}
