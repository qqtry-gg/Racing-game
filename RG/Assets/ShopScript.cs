using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] Camera MainCamera;
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
            }
            else
            {
                currentCarLook = 0;
                MainCamera.transform.position = new Vector3(507, 2.5f, 693.5f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) && isInShop)
        {
            if (currentCarLook > 0)
            {
                currentCarLook -= 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(-9.25f, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
            }
            else if (currentCarLook == 0)
            {
                currentCarLook = Cars.Count - 1;
                MainCamera.transform.position = MainCamera.transform.position + new Vector3(9.25f * Cars.Count - 1, 0f, 0f);
                MainCamera.transform.LookAt(Cars[currentCarLook]);
            }
            
        }
    }
    public void EnteredShop()
    {
        cameraController.EnterShop();
        MainCamera.transform.LookAt(Cars[0]);
        MainCamera.transform.position = new Vector3(507, 2.5f, 693.5f);
        isInShop = true;
    }
    public void ExitedShop()
    {
        cameraController.ExitShop();
        isInShop = false;
    }
}
