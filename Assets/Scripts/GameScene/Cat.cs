using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] GameObject pickUpSlider;
    [SerializeField] GameObject noteImage;
    [SerializeField] Transform player;
    [SerializeField] Animator animator;        
    public float followSpeed = 2f;    
    public float stopDistance = 2f;   

    private Rigidbody rb;
    Slider sliderPickup;
    public bool isPicked=false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sliderPickup= pickUpSlider.GetComponent<Slider>();
        if (pickUpSlider.activeSelf)
        {
            pickUpSlider.SetActive(false);
        }
    }
    private void Update()
    {
        if(player!=null && sliderPickup.value == 1f && isPicked)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * followSpeed * Time.fixedDeltaTime);

                Quaternion lookRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, Time.fixedDeltaTime * 5f));
            }
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);

        }
    }
 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TriggerCat"))
        {
            pickUpSlider.SetActive(true);
            noteImage.SetActive(false);
            StartCoroutine(SmoothSliderChange(sliderPickup, 1f, 0.1f));
        }
        if (sliderPickup.value == 1f)
        {
            isPicked = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerCat") && isPicked==false)
        {
           
            pickUpSlider.SetActive(false);
            noteImage.SetActive(true);
            sliderPickup.value = 0f;


        }
    }
    private IEnumerator SmoothSliderChange(Slider slider, float targetValue, float speed)
    {
        while (!Mathf.Approximately(slider.value, targetValue))
        {
            slider.value = Mathf.MoveTowards(slider.value, targetValue, speed * Time.deltaTime);
            yield return null;
        }

    }
}
