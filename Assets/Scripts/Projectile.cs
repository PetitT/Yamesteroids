using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {

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
