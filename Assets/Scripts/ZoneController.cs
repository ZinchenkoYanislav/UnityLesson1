using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.gameObject.name);  
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerStay");
    }
}
