using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDriver : MonoBehaviour
{
    public GameObject waitCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Educate()
    {
        if (GameController.instance.activeChild.knowledge >= 100)
        {
            GameController.instance.activeChild.knowledge = 100;
        }
        else
        {
            GameController.instance.activeChild.knowledge += 20;
        } 
        GameController.instance.activeChild.timer = 12;
        StartCoroutine(GameController.instance.activeChild.StartTimer());
        waitCircle.SetActive(true);
        UIDriver.instance.PlayUIEvent("Child was successfully educated!  Gained 20 Knowledge", UIDriver.Color.GOOD);
    }

    public void HelpAttention()
    {

    }

    public void GiveBreak()
    {
        if (GameController.instance.activeChild.frustration <= 20)
        {
            GameController.instance.activeChild.frustration = 0;
        }
        else
        {
            GameController.instance.activeChild.frustration -= 20;
        }
        GameController.instance.activeChild.timer = 12;
        StartCoroutine(GameController.instance.activeChild.StartTimer());
        waitCircle.SetActive(true);
        UIDriver.instance.PlayUIEvent("Child was sent to recess!  Frustration reduced by 25", UIDriver.Color.GOOD);
    
    }
}
