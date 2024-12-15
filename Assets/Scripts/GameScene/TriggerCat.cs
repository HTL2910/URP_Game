using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerCat : MonoBehaviour
{
    public GameObject triggerArea;
    private void Start()
    {
        if (triggerArea.activeSelf)
        {
            triggerArea.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            if (other.GetComponent<Cat>().isPicked == false)
            {
                triggerArea.SetActive(true);

            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            triggerArea.SetActive(false);
        }
    }
}
