using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : Singleton<UIManager>
{
    [Header("Count")]
    public int amount=0;//money
    public int currentStaminalCount;
    public int maxStaminalCount;
    public float minspeed = 0f;
    public float maxSpeed = 0f;
    public float currentSpeed = 0f;//
    public int priceStamina;
    public int priceSpeed;
    public int priceIncome;
    public int maxIncome=0;

    private int staminaIncreasePrice = 2;
    private int speedIncreasePrice = 3;
    private int incomeIncreasePrice = 1; 
    private int staminaIncreaseCount = 17;
    private float speedIncreaseCount = 0.2f;
    private int incomeIncreaseCount = 1;

    private float speedSlider=0.5f;
    [Header("Text")]
    public TextMeshProUGUI moneyText;//amount
    public TextMeshProUGUI staminalText;
    public TextMeshProUGUI minSpeedText;
    public TextMeshProUGUI maxSpeedText;
    public TextMeshProUGUI countStaminalText;
    public TextMeshProUGUI priceStaminalText;
    public TextMeshProUGUI countSpeedText;
    public TextMeshProUGUI priceSpeedText;  
    public TextMeshProUGUI countIncomeText;
    public TextMeshProUGUI priceIncomeText;

    [Header("GameObject")]
    public GameObject settingPanel;
    public Transform radiusSpeed;
    private float maxAngle=80f;
    private float minAngle = -80f;
    [Header("Slider")]
    public Slider staminaSlider;
    public Slider soundSlider;
    public Slider audioSlider;
    public Slider vibrationSlider;
    void Start()
    {
        CheckSetting();
        
    }
    private void Update()
    {
        View();
        ViewSlider();
        RotateWithSpeed();
    }
    private void RotateWithSpeed()
    {
        float currentAngle = Mathf.Lerp(-80f, 80f, currentSpeed / maxSpeed );
        radiusSpeed.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
    private void View()
    {
        moneyText.text = Mathf.Max(0,amount).ToString();
        staminalText.text = currentStaminalCount.ToString() + "/" + maxStaminalCount.ToString();
        minSpeedText.text = minspeed.ToString("F1");
        maxSpeedText.text = (maxSpeed * 10).ToString("F1");
        countStaminalText.text = maxStaminalCount.ToString();
        priceStaminalText.text = priceStamina.ToString();
        countSpeedText.text = maxSpeed.ToString();
        priceSpeedText.text = priceSpeed.ToString();
        countIncomeText.text = maxIncome.ToString();
        priceIncomeText.text = priceIncome.ToString();
        ViewSlider();
    }
    private void ViewSlider()
    {
        staminaSlider.value = (float)currentStaminalCount / maxStaminalCount;

    }
    public bool IsFullStamina()
    {
        return currentStaminalCount == maxStaminalCount;
    }
    /// <summary>
    /// update after
    private int SliderValue(Slider slider)
    {
        return slider.value == 0 ? 1 : 0;
    }
    public void Sound()
    {
        float targetValue = (float)SliderValue(soundSlider);
        StartCoroutine(SmoothSliderChange(soundSlider, targetValue, speedSlider));

    }

    public void Audio()
    {
        float targetValue = (float)SliderValue(audioSlider);
        StartCoroutine(SmoothSliderChange(audioSlider, targetValue, speedSlider));
    }
    public void Vibration()
    {
        float targetValue = (float)SliderValue(vibrationSlider);
        StartCoroutine(SmoothSliderChange(vibrationSlider, targetValue, speedSlider));
    }
    private IEnumerator SmoothSliderChange(Slider slider, float targetValue, float speed)
    {
        while (!Mathf.Approximately(slider.value, targetValue))
        {
            slider.value = Mathf.MoveTowards(slider.value, targetValue, speed * Time.deltaTime);
            yield return null;
        }
    }
    /// </summary>
    private void CheckSetting()
    {
        if (settingPanel.activeSelf)
        {
            CloseSetting();
        }
    }


    public void BuyStamina()
    {
        if (priceStamina <= amount)
        {
            amount-=priceStamina;
            priceStamina += staminaIncreasePrice;
            maxStaminalCount += staminaIncreaseCount;
        }
        Debug.Log("Buy Stamina");
        View();
    }
    public void BuySpeed()
    {
        if (priceSpeed <= amount)
        {
            amount -= priceSpeed;
            priceSpeed += speedIncreasePrice;
            maxSpeed += speedIncreaseCount;
        }
        Debug.Log("Buy Speed");
        View();
    }
    public void BuyIncome()
    {
        if (priceSpeed <= amount)
        {
            amount -= priceIncome;
            priceIncome += incomeIncreasePrice;
            maxIncome += incomeIncreaseCount;
        }
        Debug.Log("Buy Income");
        View();
    }
    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }
    
}
