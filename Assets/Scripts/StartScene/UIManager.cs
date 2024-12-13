using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : Singleton<UIManager>
{
    [Header("Count")]
    public int amount=0;//money
    public int currentStaminalCount;
    public int maxStaminalCount;
    public float minspeed = 0f;
    public float maxSpeed = 0f;
    public float currentSpeed = 0f;
    public int priceStamina;
    public int priceSpeed;
    public int priceIncome;
    public int maxIncome=0;
    [Header("Text")]
    public TextMeshProUGUI moneyText;//amount
    public TextMeshProUGUI staminalText;
    public TextMeshProUGUI minStaminalText;
    public TextMeshProUGUI maxStaminalText;
    public TextMeshProUGUI countStaminalText;
    public TextMeshProUGUI priceStaminalText;
    public TextMeshProUGUI countSpeedText;
    public TextMeshProUGUI priceSpeedText;  
    public TextMeshProUGUI countIncomeText;
    public TextMeshProUGUI priceIncomeText;

    [Header("GameObject")]
    public GameObject settingPanel;
    [Header("Bool")]
    public bool isSetting=false;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
