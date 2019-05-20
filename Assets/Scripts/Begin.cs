using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    float waitForStart = 3f;
    float timer = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndStart();
	}

    private void CountDownAndStart()
    {
        timer += Time.deltaTime;
        if (timer >= waitForStart)
        {
            SceneManager.LoadScene("PhysicsGame");
        }
    }
}
