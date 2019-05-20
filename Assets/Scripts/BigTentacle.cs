using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTentacle : MonoBehaviour {

    public float projectileSpeed;

	// Use this for initialization
	void Start () {
        var randomRotate = Random.Range(0, 360);
        gameObject.transform.Rotate(0, 0, randomRotate);
    }
	
	// Update is called once per frame
	void Update () {
        var randomRotate = Random.Range(0, 360);
        gameObject.transform.Rotate(0, 0, randomRotate);
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
