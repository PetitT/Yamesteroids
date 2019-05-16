using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.Translate(0, -12, 0);
    }
}
