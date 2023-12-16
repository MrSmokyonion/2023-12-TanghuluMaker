using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    [SerializeField] private int currentScore;
    [SerializeField] private int nextTrayOpenScore;

    [Space(10)]
    [SerializeField] private List<FOOD_TYPE> listOfFoodOnStick = new List<FOOD_TYPE>();
    [SerializeField] private int max_FoodOnStick;

    [Space(10)]
    [SerializeField] private Customer[] customerReference;
    [SerializeField] private int currentCustomer;

    [Space(10)]
    [SerializeField] private FoodTray[] foodTrays;
    public int currentOpenedTrayCount { get; private set; }

    [Space(10)]
    [SerializeField] private float playTimeLimit;
    [SerializeField] private float currentPlayTime;
    [SerializeField] private bool isGameOn = false;

    [Space(10)]
    [SerializeField] private float currentCustomerTimer;
    [SerializeField] private float customerTimerLimit;


    [Space(20)]
    [SerializeField] private FoodStick foodStick;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private Text gameOverScoreText;

    private void Start()
    {
        Invoke("StartGame", 3f);
    }

    private void Update()
    {
        if(isGameOn)
        {
            currentPlayTime -= Time.deltaTime;
            timerSlider.value = currentPlayTime;
        }
        if(currentPlayTime < 0f)
        {
            EndGame();
        }
        scoreText.text = currentScore.ToString();
    }

    public void StartGame()
    {
        timerSlider.maxValue = playTimeLimit;
        currentPlayTime = playTimeLimit;
        isGameOn = true;

        foodTrays[0].OpenFoodTray();
        foodTrays[1].OpenFoodTray();
        foodTrays[2].OpenFoodTray();
        currentOpenedTrayCount = 3;

        nextTrayOpenScore = 10;

        AddCustomer();
        StartCoroutine(CustomerTimer());
    }

    public void EndGame()
    {
        isGameOn = false;
        gameOverImage.SetActive(true);
        gameOverScoreText.text = "SCORE : " + currentScore.ToString();
    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void AddFoodToStick(FOOD_TYPE _food)
    {
        if (max_FoodOnStick <= listOfFoodOnStick.Count)
            return;

        listOfFoodOnStick.Add(_food);
        foodStick.PutFoodToStick(_food, listOfFoodOnStick.Count - 1);
    }

    public void ClearListOfFoodOnStick()
    {
        listOfFoodOnStick.Clear();
        foodStick.ClearStick();
    }

    public List<FOOD_TYPE> GetListOfFoodOnStick()
    {
        return listOfFoodOnStick;
    }

    public void RemoveLatestFoodOnStick()
    {
        listOfFoodOnStick.RemoveAt(listOfFoodOnStick.Count-1);
    }

    public void AddCustomer()
    {
        if (currentCustomer >= customerReference.Length)
            return;

        Order order = new Order();
        order.InitOrder();

        for(int i = 0; i < customerReference.Length; i++)
        {
            if (customerReference[i].isEmpty)
            {
                customerReference[i].InitCustomer(order); break;
            }
        }
        currentCustomer++;
    }

    IEnumerator CustomerTimer()
    {
        yield return null;
        while(isGameOn)
        {
            currentCustomerTimer += Time.deltaTime;
            if(currentCustomerTimer >= customerTimerLimit)
            {
                currentCustomerTimer = 0;
                AddCustomer();
            }
            yield return null;
        }
    }

    public void OrderCorrect()
    {
        ClearListOfFoodOnStick();
        currentScore++;
        currentCustomer--;
        currentPlayTime += 4f;
        if(currentPlayTime > playTimeLimit)
            currentPlayTime = playTimeLimit;

        if(currentScore >= nextTrayOpenScore)
        {
            if(OpenNextFoodTray())
                nextTrayOpenScore += 10;
        }
    }
    public void OrderWrong()
    {
        ClearListOfFoodOnStick();
        currentCustomer--;
        currentPlayTime -= 2f;
    }

    private bool OpenNextFoodTray()
    {
        if (currentOpenedTrayCount >= 8) return false;

        foodTrays[currentOpenedTrayCount++].OpenFoodTray();
        return true;
    }
}

public enum FOOD_TYPE
{
    none = -1,
    Strawberry = 1,
    Cherry,
    Grape,
    Banana,
    Pineapple,
    Mandarine,
    Apple,
    Gear
}

[Serializable]
public class Order
{
    public List<FOOD_TYPE> order = new List<FOOD_TYPE>();

    public void InitOrder()
    {
        for (int i = 0; i < 3; i++)
        {
            int _var = Random.Range(1, GameManager.instance.currentOpenedTrayCount+1);
            order.Add((FOOD_TYPE)(_var));
        }
    }

    public bool IsCorrectOrder(List<FOOD_TYPE> _order)
    {
        for (int i = 0; i < order.Count; i++)
        {
            if (order[i] != _order[i])
                return false;
        }
        return true;
    }
}