using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick; // Joystick để điều khiển
    [SerializeField] private float Speed = 1.5f; // Tốc độ di chuyển về phía trước
    [SerializeField] private float SideSpeed = 1f; // Tốc độ di chuyển sang trái/phải
    [SerializeField] private Animator animator; // Tốc độ di chuyển sang trái/phải
    
    void Update()
    {
        // 1. Lấy giá trị từ joystick
        float vertical = Joystick.Vertical;
        float horizontal = Joystick.Horizontal;

        // 2. Tạo vector hướng di chuyển
        Vector3 forwardMovement = Vector3.forward * vertical * Speed * Time.deltaTime;
        Vector3 sideMovement = Vector3.right * horizontal * SideSpeed * Time.deltaTime;

        // 3. Kết hợp di chuyển thẳng và ngang
        Vector3 movement = forwardMovement + sideMovement;

        // 4. Kiểm tra nếu joystick được đẩy (để tránh di chuyển khi joystick không hoạt động)
        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement, Space.Self);
            animator.SetBool("Run",true);

        }
        else
        {
            animator.SetBool("Run", false);

        }
    }
}
