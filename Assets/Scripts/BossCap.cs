using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCap : MonoBehaviour
{
    public float agreements;
    public float pass;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        agreements = 0;
        pass = 0;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        if (agreements >= 6)
        {
            Pass();
        }
    }

    void Pass()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        pass = 1;
    }
    
    
}
