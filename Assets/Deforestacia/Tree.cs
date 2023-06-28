using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movement>())
        {
            collision.GetComponent<Movement>().devastationEffects();
            Debug.Log("reduced");
            if (collision.GetComponent<Devastation>())
            {
                collision.GetComponent<Devastation>().currentDevastation -= 0.25f;
            }
            Destroy(gameObject);
        }


    }
}
