using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildController : MonoBehaviour
{
    public string childName;
    public int attentionSpan = 50;
    public int knowledge = 0;
    public int frustration = 0;
    public int level = 1;
    public int timer = 0;
    public bool waitCircleEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(DecrementKnowledge());
       StartCoroutine(IncrementFrustration());
    }

    // Update is called once per frame

    void OnMouseDown()
    {
        SetTag();
        SetOutlines();
        StartCoroutine(UpdateUI());
        //UpdateUI();
    }

    void SetOutlines()
    {
        // disable all outlines in scene.
        GameObject[] children = GameObject.FindGameObjectsWithTag("child");
        foreach (var child in children)
        {
            child.GetComponent<Outline>().enabled = false;
        }
        // enable outline for the child clicked.
        gameObject.GetComponent<Outline>().enabled = true;
    }

    void SetTag()
    {
        GameObject oldActiveChild = GameObject.FindGameObjectWithTag("ActiveChild");
        if (oldActiveChild)
        {
            oldActiveChild.tag = "child";
        }
        gameObject.tag = "ActiveChild";
    }

    IEnumerator UpdateUI()
    {
        yield return new WaitUntil(checkActiveChild);
        if (UIDriver.instance.childMenu.activeSelf)
        {
            UIDriver.instance.ToggleChildMenu();
            UIDriver.instance.ToggleChildMenu();
        }
        else
        {
            UIDriver.instance.ToggleChildMenu();
        }
    }

    IEnumerator DecrementKnowledge()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            knowledge -= 1;
            if (knowledge == 0)
            {
                Destroy(gameObject);
                UIDriver.instance.PlayUIEvent(childName + " was failed! Out of Knowledge", UIDriver.Color.BAD);
            }
        } 
    }

    IEnumerator IncrementFrustration()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            frustration += 1;
            if (frustration == 100)
            {
                Destroy(gameObject);
                UIDriver.instance.PlayUIEvent(childName + " started behaving erraticly and was expelled! Too much frustration", UIDriver.Color.BAD);
            }
        } 
    }

    bool checkActiveChild()
    {
        return GameController.instance.activeChild != null;
    }

    public IEnumerator StartTimer()
    {
        waitCircleEnabled = true;
        while (timer > 0)
        {
            timer -= 1;
            yield return new WaitForSeconds(1);
        }
        waitCircleEnabled = false;
    }
}
