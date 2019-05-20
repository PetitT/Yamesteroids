using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float rotationForce;
    public float force;
    public int health;

    public GameObject projectile;

    public Text sante;

    private string[] cheatCode;
    private int index;
    public GameObject cheat;

    public GameObject premierAsteroid;

    new Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        GameObject premier = Instantiate(premierAsteroid, premierAsteroid.transform.position, premierAsteroid.transform.rotation);
        cheatCode = new string[] { "t", "e", "n", "t", "a", "c", "u", "l", "e" };
        index = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        rigidbody2D.AddRelativeForce(Vector3.up * force * verticalInput * Time.deltaTime);
        rigidbody2D.AddTorque(horizontalInput * -rotationForce * Time.deltaTime);
    }



    // Update is called once per frame
    void Update()
    { 
        

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


        //code secret

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
                if (index == cheatCode.Length)
                {
                    GameObject Cthulu = Instantiate(cheat, cheat.transform.position, cheat.transform.rotation);
                    health = 10000;
                    index = 0;
                }
            }
            else
            {
                index = 0;
            }
        }
            

        //update santé
        string pv = health.ToString();
        sante.text = pv;

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
        new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
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
        }
        
    }
}
