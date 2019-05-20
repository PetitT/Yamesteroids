using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Asteroid1 : MonoBehaviour {

    public float asteroidSpeed;
    public GameObject upperTier;

    public GameObject sparkle;

    public static int numberOfAsteroids =  1;

    Rigidbody2D body;
	void Start () {
        var randomRotate = Random.Range(0, 360);
        gameObject.transform.Rotate(0, 0, randomRotate);
        body = GetComponent<Rigidbody2D>();
        body.AddForce(transform.up * asteroidSpeed * Time.deltaTime);
    }
	
	void Update () {
 
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

                if (upperTier != null)
                {
                    GameObject smallerAsteroid = Instantiate(upperTier, randomAsteroidPos, asteroidRotate);
                    GameObject smallerAsteroid2 = Instantiate(upperTier, randomAsteroidPos, asteroidRotate);
                    numberOfAsteroids += 2;
                }
                else
                {
                    GameObject etoiles = Instantiate(sparkle, transform.position, transform.rotation);
                }
                countscore.score += 50;
                Destroy(gameObject);
                numberOfAsteroids -= 1;

                if (numberOfAsteroids <= 0)
                {
                    SceneManager.LoadScene("Finish");
                }

                Debug.Log(numberOfAsteroids);

                break;
        }
    }
}
