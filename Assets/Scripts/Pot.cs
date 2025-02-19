using UnityEngine;

public class Pot : MonoBehaviour
{

    public int numberCollected;
    
    public Swap swap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberCollected = 0;
        swap = FindFirstObjectByType<Swap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberCollected >= 4)
        {
            Debug.Log("you win");
            swap.mSwapModel = true;
            //make maple leaf complete game
            
        }
    }

    public void IncreaseCollected()
    {
        numberCollected++;
        Debug.Log(numberCollected);
    }
}
