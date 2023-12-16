using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodTray : MonoBehaviour, IPointerDownHandler
{
    public FOOD_TYPE food;
    [SerializeField] private GameObject foodObjContainer;

    private BoxCollider2D col;
    private Animator animator;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.enabled = false;

        animator = GetComponent<Animator>();

        foodObjContainer.SetActive(false);
    }

    public void OpenFoodTray()
    {
        switch (food)
        {
            case FOOD_TYPE.Strawberry:
                animator.SetTrigger("Open_Strawberry");
                break;
            case FOOD_TYPE.Cherry:
                animator.SetTrigger("Open_Cherry");
                break;
            case FOOD_TYPE.Grape:
                animator.SetTrigger("Open_Grape");
                break;
            case FOOD_TYPE.Banana:
                animator.SetTrigger("Open_Banana");
                break;
            case FOOD_TYPE.Pineapple:
                animator.SetTrigger("Open_Pineapple");
                break;
            case FOOD_TYPE.Mandarine:
                animator.SetTrigger("Open_Mandarine");
                break;
            case FOOD_TYPE.Apple:
                animator.SetTrigger("Open_Apple");
                break;
            case FOOD_TYPE.Gear:
                animator.SetTrigger("Open_Gear");
                break;
        }
    }

    public void OnOpenAnimEnd()
    {
        col.enabled = true;
        foodObjContainer.SetActive(true);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        FoodSelectHandler.instance.OnFoodTrayClicked(food);
    }
}
