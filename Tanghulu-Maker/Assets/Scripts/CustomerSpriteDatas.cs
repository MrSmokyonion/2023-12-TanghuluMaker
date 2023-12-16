using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpriteDatas : MonoBehaviour
{
    public static CustomerSpriteDatas instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    public Sprite[] sprites;

    public Sprite GetRandomCustomerSprite()
    {
        int i = Random.Range(0, sprites.Length);
        return sprites[i];
    }
}
