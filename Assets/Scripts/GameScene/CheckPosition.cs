using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    private Vector3 originPos;
    [SerializeField] float maxDistance = 400f;
    private void Start()
    {
        originPos=transform.position;
    }
   
    void Update()
    {
        CheckPos();

    }
    private void CheckPos()
    {
        if (gameObject.transform.position.z > maxDistance)
        {
            gameObject.transform.position = originPos;
        }
    }
}
