using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid1 : MonoBehaviour {

    public float asteroidSpeed;
    public GameObject upperTier;

    public GameObject counter;

	void Start () {

        var randomRotate = Random.Range(0, 360);
        gameObject.transform.Rotate(0, 0, randomRotate); 
	}
	
	void Update () {
        gameObject.transform.position += transform.up * asteroidSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var YPos = gameObject.transform.position.y;
        var XPos = gameObject.transform.position.x;
        switch (collision.gameObject.tag)
        {
            case ("VerticalWall"):

                if (XPos > 0)
                {
                    var newXPos = XPos * (-1) + 1;
                    gameObject.transform.position = new Vector3(newXPos, YPos, 0);
                }
                else
                {
                    var newXPos = XPos * (-1) - 1;
                    gameObject.transform.position = new Vector3(newXPos, YPos, 0);
                }
                break;

            case ("HorizontalWall"):

                if (YPos > 0)
                {
                    var newYPos = YPos * (-1) + 1;
                    gameObject.transform.position = new Vector3(XPos, newYPos, 0);
                }
                else
                {
                    var newYPos = YPos * (-1) - 1;
                    gameObject.transform.position = new Vector3(XPos, newYPos, 0);
                }
                break;

            case ("Tentacule"):
                var randomAsteroidPosX = gameObject.transform.position.x + Random.Range(-2, 2);
                var randomAsteroidPosY = gameObject.transform.position.y + Random.Range(-2, 2);
                var asteroidRotate = gameObject.transform.rotation;
                var position = gameObject.transform.position;

                Vector3 randomAsteroidPos = new Vector3(randomAsteroidPosX, randomAsteroidPosY);
               
                GameObject smallerAsteroid = Instantiate(upperTier, randomAsteroidPos, asteroidRotate);
                GameObject smallerAsteroid2 = Instantiate(upperTier, randomAsteroidPos, asteroidRotate);
                countscore.score += 50;
                Destroy(gameObject);

                break;
        }
    }
}
