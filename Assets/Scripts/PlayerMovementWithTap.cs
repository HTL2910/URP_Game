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
  


    void Update()
    {
        HandleTouchInput(); 
        UpdateSpeed();

        RecoverStamina();
        MovePlayer();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && 
            UIManager.Instance.currentStaminalCount > 0 && 
            !EventSystem.current.IsPointerOverGameObject())
        {
            UIManager.Instance.currentSpeed = Mathf.Min(UIManager.Instance.currentSpeed + acceleration, UIManager.Instance.maxSpeed);
            UIManager.Instance.currentStaminalCount = Mathf.Max(UIManager.Instance.currentStaminalCount -(int) UIManager.Instance.maxSpeed, 0);
            UIManager.Instance.amount += UIManager.Instance.maxIncome;
            stepParticleSystem.Play();
            addMoneyParticleSystem.Play();
            if (UIManager.Instance.currentStaminalCount == 0)
            {
                isOutOfStamina = true;
            }

        }
    }

    void UpdateSpeed()
    {
        if (isOutOfStamina || Input.touchCount <=0) 
        {
            UIManager.Instance.currentSpeed = Mathf.Max(UIManager.Instance.currentSpeed - deceleration * Time.deltaTime, 0); 
            if (UIManager.Instance.currentSpeed == 0)
            {
                isOutOfStamina = false; 
            }
            
        }
    }

    void RecoverStamina()
    {
        if (UIManager.Instance.currentSpeed == 0)
        {
            StartCoroutine(SmoothIncrease(0.1f));
        }
        
    }

    IEnumerator SmoothIncrease(float time )
    {
        yield return new WaitForSeconds(time);
        if (!UIManager.Instance.IsFullStamina())
        {
            UIManager.Instance.currentStaminalCount += 1;
        }
    }



    void MovePlayer()
    {
        transform.Translate(Vector3.forward * UIManager.Instance.currentSpeed * Time.deltaTime);
        if (UIManager.Instance.currentSpeed > 0.1f)
        {
            animator.SetBool("Run", true);
            int tmpSpeed = Mathf.CeilToInt(Mathf.Min(UIManager.Instance.currentSpeed, 3f));
            animator.SetInteger("Movement Multiplier", tmpSpeed);
          
          
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetInteger("Movement Multiplier", 1);


        }
    }
}
