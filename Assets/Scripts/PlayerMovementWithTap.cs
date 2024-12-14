using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementWithTap : MonoBehaviour
{
    public float acceleration = 0.3f; 
    public float deceleration = 0.3f;
    public int staminaRecoveryRate = 1; 
    public float moneyGainInterval = 0.1f;

    [SerializeField] private bool isOutOfStamina = false;

    public ParticleSystem stepParticleSystem;
    public ParticleSystem addMoneyParticleSystem;
    [SerializeField] Animator animator;
    UIManager ui;
    private void Start()
    {
        ui = UIManager.Instance;
    }

    void Update()
    {
        HandleTouchInput(); 
        UpdateSpeed();

        RecoverStamina();
        MovePlayer();
        CheckPosition();
    }
    private void CheckPosition()
    {
        if (gameObject.transform.position.z > 200f)
        {
            gameObject.transform.position = Vector3.zero;
        }
    }
    void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && 
            ui.currentStaminalCount > 0 && 
            !EventSystem.current.IsPointerOverGameObject())
        {
            ui.currentSpeed = Mathf.Min(ui.currentSpeed + acceleration, ui.maxSpeed);
            ui.currentStaminalCount = Mathf.Max(ui.currentStaminalCount -(int) ui.maxSpeed, 0);
            ui.amount += ui.maxIncome;
            stepParticleSystem.Play();
            addMoneyParticleSystem.Play();
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.moneyPickClip);
            ui.CheckBuyPanel();
            if (ui.currentStaminalCount == 0)
            {
                isOutOfStamina = true;
            }

        }
    }

    void UpdateSpeed()
    {
        if (isOutOfStamina || Input.touchCount <=0) 
        {
            ui.currentSpeed = Mathf.Max(ui.currentSpeed - deceleration * Time.deltaTime, 0); 
            if (ui.currentSpeed == 0)
            {
                isOutOfStamina = false; 
            }
            
        }
    }

    void RecoverStamina()
    {
        if (ui.currentSpeed == 0)
        {
            StartCoroutine(SmoothIncrease(0.1f));
        }
        
    }

    IEnumerator SmoothIncrease(float time )
    {
        yield return new WaitForSeconds(time);
        if (!ui.IsFullStamina())
        {
            ui.currentStaminalCount += 1;
        }
    }



    void MovePlayer()
    {
        transform.Translate(Vector3.forward * ui.currentSpeed * Time.deltaTime);
        if (ui.currentSpeed > 0.1f)
        {
            animator.SetBool("Run", true);
            float tmpSpeed = Mathf.Ceil(Mathf.Min(ui.currentSpeed, 3f));
            animator.SetFloat("Movement Multiplier", tmpSpeed);
          
          
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetFloat("Movement Multiplier", 1f);


        }
    }
}
