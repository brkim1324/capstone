﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parents : MonoBehaviour
{

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }
}
