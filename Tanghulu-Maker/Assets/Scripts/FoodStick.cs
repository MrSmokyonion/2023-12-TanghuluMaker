using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodStick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform[] foodPosition;
    [SerializeField] private List<Transform> foodList;
    [SerializeField] private GameObject prefab_food;

    public void PutFoodToStick(FOOD_TYPE _food, int _position)
    {
        Transform tr = foodPosition[_position];
        GameObject obj = Instantiate(prefab_food, tr.position, tr.rotation);
        obj.GetComponent<Food>().InitFood(_food);
        foodList.Add(obj.transform);
    }

    public void ClearStick()
    {
        for(int i = foodList.Count-1; i >= 0; i--)
        {
            Destroy(foodList[i].gameObject);
            foodList.RemoveAt(i);
        }
    }

    private void RemoveLatestFoodOnStick()
    {
        Destroy(foodList[foodList.Count-1].gameObject);
        foodList.RemoveAt(foodList.Count - 1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RemoveLatestFoodOnStick();
        GameManager.instance.RemoveLatestFoodOnStick();
    }
}
