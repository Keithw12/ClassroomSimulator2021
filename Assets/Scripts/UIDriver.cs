using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDriver : MonoBehaviour
{
    public enum Color
    {
        GOOD,
        BAD
    }

    public Text eventText;
    public GameObject childMenu;
    public ProgressBar knowledgeBar;
    public ProgressBar attentionBar;
    public ProgressBar frustrationBar;
    public static UIDriver instance;
    public GameObject waitCircle;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }

    public void ToggleChildMenu()
    {
        childMenu.SetActive(!childMenu.activeSelf);
        if (GameController.instance.activeChild.waitCircleEnabled == true && childMenu.activeSelf)
        {
            waitCircle.SetActive(true);
        }
    }

    public void PlayUIEvent(string text, Color messageType)
    {
        StartCoroutine(UIEvent(text, messageType));
    }

    public IEnumerator UIEvent(string text, Color messageType)
    {
        eventText.text = text;
        if (messageType == Color.BAD)
        {
            eventText.color = new Color32(106,0,0,255);
        }
        else
        {
            eventText.color = new Color32(0,58,0,255);
        }

        
        if (eventText.enabled)
        {
            eventText.enabled = false;
            yield return new WaitForSeconds(.3f);
        }
        eventText.enabled = true;
        yield return new WaitForSeconds(4);
        eventText.enabled = false;
    }
}
