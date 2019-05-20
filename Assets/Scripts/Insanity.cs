using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insanity : MonoBehaviour {

    public GameObject projectile;

    private float time = 0.0f;
    public float interpolationPeriod = 3f;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            GameObject missile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            // execute block of code here
        }
    }
}
