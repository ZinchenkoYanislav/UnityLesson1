using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            GameController.Instance.OnKill();
        }
        //Debug.Log(other.gameObject.name);
    }
}
