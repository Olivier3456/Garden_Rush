using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    [SerializeField] UnityEvent _triggerEntered;
    private void OnTriggerEnter(Collider other)
    {
        _triggerEntered.Invoke();
        //   Debug.Log("Trigger entered.");
    }
}
