using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ChildController activeChild;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameState();
    }

    void UpdateGameState()
    {
        GameObject childObject = GameObject.FindGameObjectWithTag("ActiveChild");
        if (childObject)
        {
            activeChild = childObject.GetComponent<ChildController>();
        }
    }
}
