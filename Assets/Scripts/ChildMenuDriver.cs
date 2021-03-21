using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildMenuDriver : MonoBehaviour
{
    public Text childNameText;
    public Text childLevelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        childNameText.text = "Name: " + GameController.instance.activeChild.childName;
        childLevelText.text = "Level: " + GameController.instance.activeChild.level;
    }
}
