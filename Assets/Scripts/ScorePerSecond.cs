using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour {

	public Text scoreText;
	public float scoreAmount;
	public float pointIncreasedPerSecond;
	// Use this for initialization
	void Start () {
		scoreAmount = 0F;
		pointIncreasedPerSecond = 10F;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = (int)scoreAmount + " Score";
		scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
	}
}
