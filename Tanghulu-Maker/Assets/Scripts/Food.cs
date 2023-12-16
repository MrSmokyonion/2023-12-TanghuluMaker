using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FOOD_TYPE foodType;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void InitFood(FOOD_TYPE _food)
    {
        switch (_food)
        {
            case FOOD_TYPE.Strawberry:
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[0];
                animator.SetTrigger("Put_Strawberry");
                break;                  
            case FOOD_TYPE.Cherry:      
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[1];
                animator.SetTrigger("Put_Cherry");
                break;                  
            case FOOD_TYPE.Grape:       
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[2];
                animator.SetTrigger("Put_Grape");
                break;                  
            case FOOD_TYPE.Banana:      
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[3];
                animator.SetTrigger("Put_Banana");
                break;                  
            case FOOD_TYPE.Pineapple:   
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[4];
                animator.SetTrigger("Put_Pineapple");
                break;                  
            case FOOD_TYPE.Mandarine:   
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[5];
                animator.SetTrigger("Put_Mandarine");
                break;
            case FOOD_TYPE.Apple:
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[6];
                animator.SetTrigger("Put_Apple");
                break;
            case FOOD_TYPE.Gear:
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[7];
                animator.SetTrigger("Put_Gear");
                break;
        }
    }
}