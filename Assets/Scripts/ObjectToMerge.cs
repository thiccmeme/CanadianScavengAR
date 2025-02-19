using System;
using UnityEngine;

public class ObjectToMerge : MonoBehaviour
{

    public GameObject pot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pot = FindFirstObjectByType<Pot>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pot"))
        {
            pot.GetComponent<Pot>().IncreaseCollected();
            Destroy(this.gameObject);
        }
    }
}
