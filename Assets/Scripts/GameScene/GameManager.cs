using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider playerSlider;
    [SerializeField] private Slider waveSlider;

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform waveTransform;
    [SerializeField] Transform endTransform;
    public Transform[] catPositions; 
    public RectTransform[] catIcons;
    private float totalDistance;

    private void Start()
    {
        totalDistance = endTransform.position.z;
        playerSlider.minValue = 0f;
        playerSlider.maxValue = totalDistance;
        waveSlider.minValue = 0f;
        waveSlider.maxValue = totalDistance;
    }
    private void Update()
    {
        playerSlider.value = Mathf.Clamp(playerTransform.position.z, 0, totalDistance);
        waveSlider.value = Mathf.Clamp(waveTransform.position.z, 0, totalDistance);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("StartScene");
    }
   
}
