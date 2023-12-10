using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpriteDatas : MonoBehaviour
{
    public static FoodSpriteDatas instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public Sprite[] sprites;
}
