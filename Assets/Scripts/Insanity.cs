using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanity : MonoBehaviour {

    public GameObject projectile;
    float waitForShot = 0.1f;
    float timer = 0.0f;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        timer += Time.deltaTime;
        if (timer >= waitForShot) 
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject missile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        timer -= waitForShot;
    }
}
