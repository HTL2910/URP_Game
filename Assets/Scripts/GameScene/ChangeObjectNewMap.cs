using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectNewMap : MonoBehaviour
{
    private float radius = 20f;

    private void Start()
    {
        float x = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);
        float rot = Random.Range(0f, 360f);
        transform.SetPositionAndRotation(transform.position + new Vector3(x, 0f, z),
            Quaternion.Euler(0f, rot, 0f));
       
    }
}
