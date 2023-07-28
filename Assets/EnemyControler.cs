using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
