using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;
    [SerializeField] private float Speed = 1.5f; 
    [SerializeField] private float SideSpeed = 1f;
    [SerializeField] private Animator animator;
    public bool isDead=false;
    void Update()
    {
        if (!isDead)
        {
            float vertical = Joystick.Vertical;
            float horizontal = Joystick.Horizontal;

            Vector3 forwardMovement = Vector3.forward * vertical * Speed * Time.deltaTime;
            Vector3 sideMovement = Vector3.right * horizontal * SideSpeed * Time.deltaTime;

            Vector3 movement = forwardMovement + sideMovement;

            if (movement.magnitude > 0.1f)
            {
                transform.Translate(movement, Space.Self);
                animator.SetBool("Run", true);

            }
            else
            {
                animator.SetBool("Run", false);

            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tsunami"))
        {
            isDead = true;
        }
    }
}
