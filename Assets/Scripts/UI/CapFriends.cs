using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapFriends : MonoBehaviour
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
        TotalNumber.text = "Capsule Friends:"+ globalScript.GetComponent<Global>().CapFriends.ToString("0");
    }
}
