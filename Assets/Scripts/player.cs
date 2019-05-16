using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        transform.position += (Vector3)move * speed * Time.deltaTime; //déplacement

        // Rotate left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        // Rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
    }
}
