using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject currentCamera;
    public GameObject nextCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>()) // checks for player
        {
            Debug.Log("TestPos");
            if (currentCamera.activeInHierarchy)
            {
                currentCamera.SetActive(false);
                nextCamera.SetActive(true);
                Debug.Log("currentCamera > nextCamera");
                return;
            }

            if (nextCamera.activeInHierarchy)
            {
                currentCamera.SetActive(true);
                nextCamera.SetActive(false);
                Debug.Log("nextCamera > currentCamera");
            }
        }
    }
}
