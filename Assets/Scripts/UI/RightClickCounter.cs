using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightClickCounter : MonoBehaviour
{
    public Text Counter;
    public GameObject globalScirpt;
    
    // Start is called before the first frame update
    void Start()
    {
        globalScirpt.GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        Counter.text = globalScirpt.GetComponent<Global>().RightClickCounter.ToString("0");
    }
}
