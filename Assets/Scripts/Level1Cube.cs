﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Cube : MonoBehaviour
{
    public GameObject target;
    private Vector3 scaleChange;
    public float sizeX;
    public float sizeY;
    public float sizeZ;
    public float fireSpeed;
    public GameObject bullet;
    public Transform firepoint;
    public float _canFire = -1.0f;
    
    
    private Rigidbody myRB;
    public Player thePlayer;
    public float moveSpeed;

    public float npcType; 

    public Transform PlayerDistance;
    public Transform FriendDistance;
    public GameObject Friend;

    private float likePlayer;
    private float friendPlayer;
    private int hitFriendNumber;
    public int hitNumber;
    private int Active;
    public int beFriended;
    public int Follow;
    public float FollowActive;

    public GameObject bulletGood;

    public GameObject globalScript;
    public GameObject playerScript;
    
    private float FriendIncentive;


    public Material nMaterial;
    private int BehaviorType;

    private float currentTime = 0;
    private float startingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<Player>();
        
        beFriended = 0;
        Follow = 0;
        FollowActive = 0;
        hitNumber = 0;

         
        globalScript.GetComponent<Global>();
        playerScript.GetComponent<Player>();
        globalScript.GetComponent<Global>().TotalShapes += 1;
        //FriendIncentive = globalScript.GetComponent<Global>().CubeFriends;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

        BehaviorType = Random.Range(0, 3);
        Debug.Log(BehaviorType);


    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, PlayerDistance.position);

        if (distance <= 6)
        {
            transform.LookAt(thePlayer.transform.position);
        }

        if (beFriended == 1 && Follow == 1 && FollowActive ==1)
        {
            PlayerFollow();
        }
        
 
        
        if (Time.time > currentTime && hitNumber < 5)
        {
       
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            currentTime = Time.time + startingTime;

        }
      
        
    }
    
    void FixedUpdate()
    {
        //myRB.velocity = (transform.forward * moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {
       // if (col.gameObject.tag == "Cube")
      //  {
           
          //  scaleChange = new Vector3(-sizeX,-sizeY,-sizeZ);
           // target.transform.localScale -= scaleChange;
           // Destroy(col.collider.gameObject);
            
       // }

       // if (col.gameObject.tag == "Sphere")
      //  {
          //  scaleChange = new Vector3(sizeX,sizeY,sizeZ);
         //   target.transform.localScale -= scaleChange;
         //   Destroy(col.collider.gameObject);
     //   }

        if (col.gameObject.tag == "PColor")
        {
            hitNumber += 1;
            globalScript.GetComponent<Global>().RightClickCounter -= 1;
            playerScript.GetComponent<Player>().scaleChangeDown();
            PlayerNearBy();
            
            Destroy(col.collider.gameObject);

            if (BehaviorType == 0)
            {
                Neutral();
            }

            if (BehaviorType == 1)
            {
                Friendly();
            }

            if (BehaviorType == 2)
            {
                Hostile();
            }
                
            

           
            if (hitNumber == 5)
            {
                globalScript.GetComponent<Global>().Level_1_Clear = 1;
                beFriended = 1;
            }
            
           
        }
    }

    void FindFriend()
    {
        float distance = Vector3.Distance(transform.position, FriendDistance.position);
        if (distance <= 5)
        {
            transform.LookAt(Friend.transform.position);
        
            if (Time.time > _canFire)
            {
                _canFire = Time.time + fireSpeed;
                Instantiate(bullet, firepoint.position, firepoint.rotation);
            }
        }
    }

    void PlayerNearBy()
    {
        transform.LookAt(thePlayer.transform.position);
        
    }

    void Hostile()
    {
        transform.LookAt(thePlayer.transform.position);
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        
        if (Time.time > _canFire)
        {
            _canFire = Time.time + fireSpeed;
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
        
    }

    void Neutral()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        transform.LookAt(thePlayer.transform.position);

       

    }

    void Friendly()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        transform.LookAt(thePlayer.transform.position);
        
        if (Time.time > _canFire)
        {
            _canFire = Time.time + fireSpeed;
            Instantiate(bulletGood, firepoint.position, firepoint.rotation);
        }
    }

    void PlayerFollow()
    {
        transform.LookAt(thePlayer.transform.position);
        myRB.velocity = (transform.forward * moveSpeed);
    }
}
