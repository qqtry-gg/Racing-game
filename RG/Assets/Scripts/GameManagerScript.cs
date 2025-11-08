using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public int Cash = 0;
    [SerializeField] TextMeshProUGUI CoinsCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinsCounter.text = "Cash: " + Cash.ToString();
    }
    public void PurchasingCar(int carPrice)
    {
        if (Cash >= carPrice)
        {
            Cash -= carPrice;
            //Rest of the logic for later P:
        }
    }
    public void EarningCoins(int amount)
    {
        Cash += amount;
    }
}
