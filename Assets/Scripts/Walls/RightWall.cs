using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.Translate(-14, 0, 0);
    }
}
