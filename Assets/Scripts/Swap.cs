using UnityEngine;
using Vuforia;

public class Swap : MonoBehaviour
{
    public ObserverBehaviour mTarget;
    public bool mSwapModel = false;
    public GameObject leaf;
    public GameObject canvas;

    // Use this for initialization
    void Start()
    {
        canvas.SetActive(false);
        if (mTarget == null)
        {
            Debug.Log("Warning: Target not set !!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (mSwapModel && mTarget != null)
        {
            SwapModel();
            canvas.SetActive(true);
            mSwapModel = false;
        }
    }
    private void SwapModel()
    {
        // Disable any pre-existing augmentation
        GameObject mExistingModel = mTarget.gameObject;
        
        for (int i = 0; i < mExistingModel.transform.childCount; i++)
        {
            Transform child = mExistingModel.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        // Create a simple cube object
        GameObject cube = Instantiate(leaf,mTarget.transform);

        // Re-parent the cube as child of the trackable gameObject

        // Adjust the position and scale
        // so that it fits nicely on the target
        cube.transform.localPosition = new Vector3(0, 0.2f, 0);
        cube.transform.localRotation = Quaternion.identity;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // Make sure it is active
        cube.SetActive(true);
    }
}

