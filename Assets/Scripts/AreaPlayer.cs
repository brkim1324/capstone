using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPlayer : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Player;
    public float PlayerAreaScore;
    public float StayPlusScore;
    public float MinusPerSecond;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAreaScore -= MinusPerSecond * Time.deltaTime;

        if (PlayerAreaScore <= 50)
        {
            Plane.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        else
        {
            Plane.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        if (PlayerAreaScore >= 100)
        {
            PlayerAreaScore = 100;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerAreaScore += StayPlusScore * Time.deltaTime;
    }

   
    
}
