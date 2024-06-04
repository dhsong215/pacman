using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Score.pelletAmount += 1;
        Destroy(gameObject);
    }
    
}
