using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    public enum BarType
    {
        Knowledge,
        Attention,
        Frustration
    }

    [Header("Title Setting")]
    public BarType barType;
    public string Title;
    public Color TitleColor;
    public Font TitleFont;
    public int TitleFontSize = 10;

    [Header("Bar Setting")]
    public Color BarColor;   
    public Color BarBackGroundColor;
    public Sprite BarBackGroundSprite;
    [Range(1f, 100f)]
    public int Alert = 20;
    public Color BarAlertColor;

    [Header("Sound Alert")]
    public AudioClip sound;
    public bool repeat = false;
    public float RepeatRate = 1f;

    private Image bar, barBackground;
    private float nextPlay;
    private AudioSource audiosource;
    private Text txtTitle;
    private float barValue;
    public float BarValue
    {
        get { return barValue; }

        set
        {
            value = Mathf.Clamp(value, 0, 100);
            barValue = value;
            UpdateValue(barValue);
        }
    }
    private ChildController activeChild;

    //void OnEnable()
    //{
    //     // set bar value based on bar type with active child
    //     activeChild = GameObject.FindGameObjectWithTag("ActiveChild").GetComponent<ChildController>();
    // }        

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        barBackground = GetComponent<Image>();
        txtTitle = transform.Find("Text").GetComponent<Text>();
        barBackground = transform.Find("BarBackground").GetComponent<Image>();
        audiosource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        txtTitle.text = Title;
        txtTitle.color = TitleColor;
        txtTitle.font = TitleFont;
        txtTitle.fontSize = TitleFontSize;

        bar.color = BarColor;
        barBackground.color = BarBackGroundColor; 
        barBackground.sprite = BarBackGroundSprite;

        UpdateValue(barValue);


    }

    void UpdateValue(float val)
    {
        bar.fillAmount = val / 100;
        txtTitle.text = Title + " " + val + "%";

        if (Alert >= val)
        {
            bar.color = BarAlertColor;
        }
        else
        {
            bar.color = BarColor;
        }

    }


    private void Update()
    {
        switch (barType)
        {
            case BarType.Knowledge:
                BarValue = GameController.instance.activeChild.knowledge;
                break;
            case BarType.Attention:
                BarValue = GameController.instance.activeChild.attentionSpan;
                break;
            case BarType.Frustration:
                BarValue = GameController.instance.activeChild.frustration;
                break;
            default:
                break;
        }
        if (!Application.isPlaying)
        {           
            UpdateValue(50);
            txtTitle.color = TitleColor;
            txtTitle.font = TitleFont;
            txtTitle.fontSize = TitleFontSize;

            bar.color = BarColor;
            barBackground.color = BarBackGroundColor;

            barBackground.sprite = BarBackGroundSprite;           
        }
        else
        {
            if (Alert >= barValue && Time.time > nextPlay)
            {
                nextPlay = Time.time + RepeatRate;
                audiosource.PlayOneShot(sound);
            }
        }
    }

}
