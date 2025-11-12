using UnityEngine;

public class EnteredShop : MonoBehaviour
{
    [SerializeField] ShopScript shopScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        shopScript.EnteredShop();
    }
}
