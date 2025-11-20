using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManagerScript;
    CarController CurrentCarDetails;
    [SerializeField] CameraController cameraController;
    [SerializeField] Camera MainCamera;
    [SerializeField] GameObject ShopUI;
    [Header("CarDetailsForGUI")]
    [SerializeField] TMPro.TextMeshProUGUI CarName1;
    [SerializeField] TMPro.TextMeshProUGUI CarPrice1;
    [SerializeField] TMPro.TextMeshProUGUI MaxSpeed1;
    [SerializeField] TMPro.TextMeshProUGUI MotorPower1;
    [SerializeField] TMPro.TextMeshProUGUI BreakingPower1;
    [SerializeField] TMPro.TextMeshProUGUI SteeringDifficulty1;
    [SerializeField] TMPro.TextMeshProUGUI PurchaseButton;
    public List<Transform> Cars = new List<Transform>();
    int currentCarLook = 0;
    bool isInShop = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isInShop)
        {
            if (currentCarLook < Cars.Count - 1)
            {
                currentCarLook += 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(9.25f, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
            else
            {
                currentCarLook = 0;
                MainCamera.transform.position = new Vector3(507, 2.5f, 693.5f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) && isInShop)
        {
            if (currentCarLook > 0)
            {
                currentCarLook -= 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(-9.25f, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
            else if (currentCarLook == 0)
            {
                currentCarLook = Cars.Count - 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(9.25f * (Cars.Count - 1), 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
            
        }
    }
    public void EnteredShop()
    {
        cameraController.EnterShop();
        MainCamera.transform.LookAt(Cars[0]);
        MainCamera.transform.position = new Vector3(507, 2.5f, 693.5f);
        CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
        SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
        isInShop = true;
    }
    public void ExitedShop()
    {
        cameraController.ExitShop();
        ShopUI.SetActive(false);
        isInShop = false;
    }
    public void GoLeft()
    {
        if (isInShop)
        {
            if (currentCarLook > 0)
            {
                currentCarLook -= 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(-9.25f, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
            else if (currentCarLook == 0)
            {
                currentCarLook = Cars.Count - 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(9.25f * Cars.Count - 1, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }

        }
    }
    public void GoRight()
    {
        if (isInShop)
        {
            if (currentCarLook < Cars.Count - 1)
            {
                currentCarLook += 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(9.25f, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
            else
            {
                currentCarLook = 0;
                MainCamera.transform.position = new Vector3(507, 2.5f, 693.5f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
                CurrentCarDetails = Cars[currentCarLook].GetComponent<CarController>();
                SetCarDetails(CurrentCarDetails.name, CurrentCarDetails.price, CurrentCarDetails.maxSpeed, CurrentCarDetails.motorPower, CurrentCarDetails.brakepower, CurrentCarDetails.SteeringDifficulty);
            }
        }
    }
    public void SetCarDetails(string CarName, float CarPrice, float MaxSpeed, float MotorPower, float BreakingPower, string SteeringDifficulty)
    {
        CarName1.text = CarName;
        CarPrice1.text = "Price: " + CarPrice.ToString() + "$";
        MaxSpeed1.text = "Max Speed: " +  MaxSpeed.ToString();
        MotorPower1.text = "Motor Power: " + MotorPower.ToString();
        BreakingPower1.text = "Break Power: " + BreakingPower.ToString();
        SteeringDifficulty1.text = "Steering Difficulty: " + SteeringDifficulty;
    }
    public void BuyCar()
    {
        CarController CarControllerScript = Cars[currentCarLook].GetComponent<CarController>();
        if (gameManagerScript.Cash >= CarControllerScript.price && !CarControllerScript.HasTheCarPurchased)
        {
            gameManagerScript.Cash -= CarControllerScript.price;
            CarControllerScript.HasTheCarPurchased = true;
            PurchaseButton.text = "Purchased";
        }
        else if (PurchaseButton.text != "Using" && CarControllerScript.HasTheCarPurchased)
        {
            PurchaseButton.text = "Using";
        }
        else if (PurchaseButton.text != "Purchased" && CarControllerScript.HasTheCarPurchased)
        {
            PurchaseButton.text = "Purchased";
        }
        else
        {
            PurchaseButton.text = "Purchase";
        }
    }
}
