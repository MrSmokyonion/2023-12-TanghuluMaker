using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Customer : MonoBehaviour, IPointerClickHandler
{
    public bool isEmpty = true;
    [SerializeField] private Order order;
    [SerializeField] private GameObject spriteContainer;
    [SerializeField] private Food[] foods;

    public void InitCustomer(Order _order)
    {
        if(!isEmpty) { return; }
        isEmpty = false;
        order = _order;

        //¼Õ´Ô UI Ãâ·Â
        spriteContainer.SetActive(true);
        for (int i = 0; i < foods.Length; i++) 
        {
            foods[i].InitFood(order.order[i]);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        spriteContainer.SetActive(false);
        isEmpty = true;
        if (order.IsCorrectOrder(GameManager.instance.GetListOfFoodOnStick()))
        {
            GameManager.instance.OrderCorrect();
        }
        else
        {
            GameManager.instance.OrderWrong();
        }
    }
}
