using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : MonoBehaviour
{
    private float v1 = 10f;
    private float v2 = 40f;
    private float v;
    private bool isMove = false;
    private float time = 15f;
    private void Start()
    {
        v = v1;
        StartCoroutine(Move(time));
    }
    private void Update()
    {
        if (isMove)
        {
            transform.Translate(Vector3.forward * v * Time.deltaTime);
        }

    }
    IEnumerator Move(float time)
    {
        yield return new WaitForSeconds(time);
        isMove = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            v = v2;
        }
    }
}
