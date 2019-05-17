using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    public float backSpeed;
    public int health;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // déplacements
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.up * Time.deltaTime * backSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }

        // tirer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // die
        if (health <= 0)
        {
            Die();
        }

    }

    private void Shoot()
    {
        var launcher = gameObject.transform.position;
        var rotation = gameObject.transform.rotation;
        GameObject tentacule = Instantiate(projectile, launcher, rotation);
    }

    private void Die()
    {
        Destroy(gameObject);
        new WaitForSeconds(3);
        Debug.Log("Lol U ded");
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

            case ("Asteroid"):
                health -= 50;
                break;

            default:
                break;
        }
        
    }
}
