using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject currentCamera;
    public GameObject NextCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>()) // checks for player
        {
            currentCamera.SetActive(false);
            NextCamera.SetActive(true);

            if (NextCamera.activeInHierarchy)
            {
                currentCamera.SetActive(true);
                NextCamera.SetActive(false);
            }
        }
    }
}
