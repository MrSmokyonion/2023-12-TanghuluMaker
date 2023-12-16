using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Table
{
    [SerializeField]
    int key;
    public int Key { get => key; }


    [SerializeField]
    float life_NaturalDecrease = 1.0f;
    public float Life_NaturalDecrease { get => life_NaturalDecrease; }
    [SerializeField]
    float life_FailDecrease = 2.0f;
    public float Life_FailDecrease { get => life_FailDecrease; }
    [SerializeField]
    float life_SuccessIncrease = 4.0f;
    public float Life_SuccessIncrease { get => life_SuccessIncrease; }
    

    [SerializeField]
    float time_CustomerSpawn;
    public float Time_CustomerSpawn { get => time_CustomerSpawn; }
    [SerializeField]
    float time_CustomerExit;
    public float Time_CustomerExit { get => time_CustomerExit; }


    [SerializeField]
    bool fruit_1 = true;
    [SerializeField]
    bool fruit_2 = true;
    [SerializeField]
    bool fruit_3 = true;
    [SerializeField]
    bool fruit_4;
    [SerializeField]
    bool fruit_5;
    [SerializeField]
    bool fruit_6;
    [SerializeField]
    bool fruit_7;
    [SerializeField]
    bool fruit_8;

    public bool IsFruitEnable(FOOD_TYPE InFood)
    {
        switch(InFood)
        {
            case FOOD_TYPE.Strawberry:
                return fruit_1;
            case FOOD_TYPE.Cherry:
                return fruit_2;
            case FOOD_TYPE.Grape:
                return fruit_3;
            case FOOD_TYPE.Banana:
                return fruit_4;
            case FOOD_TYPE.Pineapple:
                return fruit_5;
            case FOOD_TYPE.Mandarine:
                return fruit_6;
            case FOOD_TYPE.Apple:
                return fruit_7;
            case FOOD_TYPE.Gear:
                return fruit_8;
            default:
                return false;
        }
    }
}


[Serializable]
public struct TableManager
{
    [SerializeField]
    Table[] tables;
    SortedDictionary<int, Table> sortedTables;
    List<int> keys;

    public Table GetTable(int InSeccond)
    {
        if (keys == null || keys?.Count != tables.Length)
        {
            sortedTables = new();
            foreach (Table table in tables)
            {
                sortedTables.Add(table.Key, table);
            }

            keys = new(sortedTables.Keys);
        }

        return sortedTables[keys.BinarySearch(InSeccond)];
    }
}