using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FOOD_TYPE foodType;
    [SerializeField] private SpriteRenderer spriteRenderer;

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
                break;                  
            case FOOD_TYPE.Cherry:      
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[1];
                break;                  
            case FOOD_TYPE.Grape:       
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[2];
                break;                  
            case FOOD_TYPE.Banana:      
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[3];
                break;                  
            case FOOD_TYPE.Pineapple:   
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[4];
                break;                  
            case FOOD_TYPE.Mandarine:   
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[5];
                break;
            case FOOD_TYPE.Apple:
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[6];
                break;
            case FOOD_TYPE.Gear:
                spriteRenderer.sprite = FoodSpriteDatas.instance.sprites[7];
                break;
        }
    }
}