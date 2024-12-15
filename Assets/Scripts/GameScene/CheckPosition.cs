using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    private Vector3 originPos;
    private void Start()
    {
        originPos=transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            CheckPos();
        }
    }
    private void CheckPos()
    {
       
        gameObject.transform.position = originPos;
        
    }
}
