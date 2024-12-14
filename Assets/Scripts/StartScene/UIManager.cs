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

    [Header("Feature")]
    
    public GameObject settingPanel;
    public Transform radiusSpeed;
    private float maxAngle=80f;
    private float minAngle = -80f;
    [Header("Slider")]
    [SerializeField] Slider staminaSlider;
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider audioSlider;
    [SerializeField] Slider vibrationSlider;

    [Header("CheckCount")]
    [SerializeField] Image staminaPanel;
    [SerializeField] Image speedPanel;
    [SerializeField] Image incomePanel;
    private Color blueColor= new Color(100f / 255f, 100f / 255f, 250f / 255f, 255f / 255f);//blue
    private Color orangeColor= new Color(250 / 255f, 100f / 255f, 0f / 255f, 255f / 255f);//orange 
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
        float currentAngle = Mathf.Lerp(minAngle, maxAngle, currentSpeed / maxSpeed );
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
    /// <Slider>
    /// update after
    private void ViewSlider()
    {
        staminaSlider.value = (float)currentStaminalCount / maxStaminalCount;

    }
    public bool IsFullStamina()
    {
        return currentStaminalCount == maxStaminalCount;
    }
   
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
    /// </Slider>


    /// <Buy>
    private void CheckBuy(int count, Image panel)
    {
        if (count <= amount)
        {
            panel.color = blueColor;//blue

        }
        else
        {
            panel.color = orangeColor;
        }
    }
    public void CheckBuyPanel()
    {
        CheckBuy(priceStamina, staminaPanel);
        CheckBuy(priceSpeed, speedPanel);
        CheckBuy(priceIncome, incomePanel);

    }
    public void BuyStamina()
    {
        if (priceStamina <= amount)
        {
            amount -= priceStamina;
            priceStamina += staminaIncreasePrice;
            maxStaminalCount += staminaIncreaseCount;
        }

        CheckBuyPanel();
    }
    public void BuySpeed()
    {
        if (priceSpeed <= amount)
        {
            amount -= priceSpeed;
            priceSpeed += speedIncreasePrice;
            maxSpeed += speedIncreaseCount;
        }
        CheckBuyPanel();
    }

    public void BuyIncome()
    {
        if (priceIncome <= amount)
        {
            amount -= priceIncome;
            priceIncome += incomeIncreasePrice;
            maxIncome += incomeIncreaseCount;
        }
        CheckBuyPanel();
    }
   
    /// </Buy>

    /// <Setting>
    private void CheckSetting()
    {
        if (settingPanel.activeSelf)
        {
            CloseSetting();
        }
    }
    public void Setting()
    {
        settingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }
    /// </Setting>
}
