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
    private Coroutine coroutine;
    [SerializeField] private GameObject prefab_correctSign;
    [SerializeField] private GameObject prefab_wrongSign;

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
        coroutine = StartCoroutine(OnCustomerEnter());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isEmpty) return;

        spriteContainer.SetActive(false);
        isEmpty = true;
        if (order.IsCorrectOrder(GameManager.instance.GetListOfFoodOnStick()))
        {
            GameManager.instance.OrderCorrect();
            Instantiate(prefab_correctSign, transform.position, transform.rotation);
        }
        else
        {
            GameManager.instance.OrderWrong();
            Instantiate(prefab_wrongSign, transform.position, transform.rotation);
        }
        StopCoroutine(coroutine);
    }

    IEnumerator OnCustomerEnter()
    {
        yield return null;
        
        float curTime = GameManager.instance.GetTable().Time_CustomerExit;
        timer.maxValue = curTime;

        while (true)
        {
            curTime -= Time.deltaTime;
            timer.value = curTime;

            if (curTime < 0f)
            {
                spriteContainer.SetActive(false);
                isEmpty = true;
                if(GameManager.instance.isGameOn)
                {
                    GameManager.instance.OrderWrong(false);
                    Instantiate(prefab_wrongSign, transform.position, transform.rotation);
                }
                break;
            }
            yield return null;
        }
    }
}
