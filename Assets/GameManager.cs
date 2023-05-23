using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int wood;
    public Text woodDisplay;

    private Building buildingToPlace;
    public GameObject grid;

    public CustomCursor customCursor;

    public void Update()
    {
        woodDisplay.text = wood.ToString();
    }

    public void CreateBuilding(Building building)
    {
        if(wood >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            wood -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}
