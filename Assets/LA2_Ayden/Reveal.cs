using UnityEngine;
using UnityEngine.UIElements;

public class Reveal : MonoBehaviour
{

    public Button button;
    public int i = 0;

    public Cap[] objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objects = FindObjectsByType<Cap>(FindObjectsSortMode.None);
        foreach (var obj in objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public void Press()
    {
        if (i < objects.Length)
        {
            var obj = objects[i];
            obj.gameObject.SetActive(true);

            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
