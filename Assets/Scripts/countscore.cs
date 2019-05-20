using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countscore : MonoBehaviour {


    public static int score = 0;
    public Text points;
    string scoreText = score.ToString();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        points.text = scoreText;
	}





}
