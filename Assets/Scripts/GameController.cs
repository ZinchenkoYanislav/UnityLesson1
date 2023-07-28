using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject Enemy;
    public TextMeshProUGUI scroeText;

    private int score = 0;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void OnKill()
    {
        score++;
        //Instantiate(Enemy, transform.position + new Vector3(3, 1, 3), Quaternion.identity);
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1)), Quaternion.identity);
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        scroeText.text = $"Score: {score}"; 
    }
}
