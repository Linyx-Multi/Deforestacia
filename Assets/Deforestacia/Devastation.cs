using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Devastation : MonoBehaviour
{
    public bool isDead;
    public float maxDevastation = 1f;
    public float currentDevastation = 1f;
    public Slider devBar;

    private void Update()
    {
        devBar.value = currentDevastation / maxDevastation;

        if (currentDevastation <= 0f)
        {
            isDead = true;
        }

        if (isDead)
        {
            SceneManager.LoadScene(2);
        }
    }
}
