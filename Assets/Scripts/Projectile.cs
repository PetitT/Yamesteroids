using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += transform.up * projectileSpeed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("VerticalWall"):
                Destroy(gameObject);
                break;

            case ("HorizontalWall"):
                Destroy(gameObject);
                break;

            case ("Asteroid"):
                Destroy(gameObject);
                break;            
        }
    }
}
