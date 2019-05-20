using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countscore : MonoBehaviour {


    public static int score = 0;
    public Text points;
    int remainingAsteroids = Asteroid1.numberOfAsteroids;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string scoreText = score.ToString();
        points.text = scoreText;

        if (remainingAsteroids <= 0)
        {
            Finish();
        }
	}

    
    void Finish()
    {
        SceneManager.LoadScene("Finish");
    }


}
