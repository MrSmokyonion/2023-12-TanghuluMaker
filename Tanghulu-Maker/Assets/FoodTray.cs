using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodTray : MonoBehaviour, IPointerClickHandler
{
    public FOOD_TYPE food;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("sdfsdf");
        GameManager.instance.AddFoodToStick(food);
    }
}
