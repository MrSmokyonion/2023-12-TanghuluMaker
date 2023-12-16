using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelectHandler : MonoBehaviour
{
    public static FoodSelectHandler instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    [SerializeField] private FOOD_TYPE selectedFood;
    [SerializeField] private Food foodObject;
    private Transform foodObjectTransform;

    private bool isSelected = false;


    private void Start()
    {
        foodObjectTransform = foodObject.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.collider.CompareTag("FoodStick"))
                {
                    OnFoodDroppedOnStick();
                }
                else
                {
                    OnFoodDroppedElse();
                }
            }
            else
            {
                OnFoodDroppedElse();
            }
        }

        if (isSelected)
        {
            

            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            foodObjectTransform.position = mousePos;
        }
        else
        {
            foodObjectTransform.position = new Vector2(30f, -5f);
        }
    }

    public void OnFoodTrayClicked(FOOD_TYPE _foodType)
    {
        selectedFood = _foodType;
        foodObject.InitFood(_foodType);
        isSelected = true;
    }

    public void OnFoodDroppedOnStick()
    {
        if (!isSelected) return;

        GameManager.instance.AddFoodToStick(selectedFood);
        isSelected = false;
        selectedFood = FOOD_TYPE.none;
    }

    public void OnFoodDroppedElse()
    {
        isSelected = false;
        selectedFood = FOOD_TYPE.none;
    }
}
