using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Customer : MonoBehaviour, IPointerClickHandler
{
    public bool isEmpty = true;
    [SerializeField] private Order order;
    [SerializeField] private GameObject spriteContainer;
    [SerializeField] private Food[] foods;
    [SerializeField] private SpriteRenderer customerSprite;
    [SerializeField] private Slider timer;

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
        customerSprite.sprite = CustomerSpriteDatas.instance.GetRandomCustomerSprite();
        StartCoroutine(OnCustomerEnter());
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

    IEnumerator OnCustomerEnter()
    {
        yield return null;
        timer.maxValue = 10;
        float curTime = 10;
        while (true)
        {
            curTime -= Time.deltaTime;
            timer.value = curTime;

            if (curTime < 0f)
            {
                spriteContainer.SetActive(false);
                isEmpty = true;
                if(GameManager.instance.isGameOn)
                    GameManager.instance.OrderWrong(false);
                break;
            }
            yield return null;
        }
    }
}
