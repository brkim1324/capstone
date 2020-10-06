using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalShapes : MonoBehaviour
{
    public GameObject globalScript;

    public Text TotalNumber;

    public float Total;
    // Start is called before the first frame update
    void Start()
    {
        globalScript.GetComponent<Global>();
        //Total = globalScript.GetComponent<Global>().TotalShapes;
    }

    // Update is called once per frame
    void Update()
    {
        TotalNumber.text = "Total Shapes:"+ globalScript.GetComponent<Global>().TotalShapes.ToString("0");
    }
}
