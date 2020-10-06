using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
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
    public float hitNumber;
    private int Active;
    private float neutralCounter;

    public GameObject bulletGood;

    public GameObject globalScript;
    
    public float neutralState;
    private float friendState;

    
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<Player>();
        
        likePlayer = Random.Range(0f, 5f);
        

        hitFriendNumber = Random.Range(2, 5);
        
        hitNumber = 0;
        neutralCounter = 5;

        Active = 0;
       

        globalScript.GetComponent<Global>();
        
        globalScript.GetComponent<Global>().TotalShapes += 1;

        neutralState = 0;
        friendState = 0;


    }

   
    void Update()
    {

        float distance = Vector3.Distance(transform.position, PlayerDistance.position);
       
        if (distance <= 6)
        {
            PlayerNearBy();
        }
        
        

        Neutral();

        

        if (neutralCounter <= 0)
        {
            neutralState = 1;
        }
        
        
    }
    
    void FixedUpdate()
    {
        //myRB.velocity = (transform.forward * moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "PColor")
        {
            globalScript.GetComponent<Global>().RightClickCounter -= 1;
            PlayerNearBy();

            if (neutralState == 0)
            {
                Instantiate(bullet, firepoint.position, firepoint.rotation);
                neutralCounter -= 1;
                Destroy(col.collider.gameObject);
            }
            
            
          

            if (neutralState == 1)
            {
                hitNumber += 1;
                Instantiate(bulletGood, firepoint.position, firepoint.rotation);
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                Destroy(col.collider.gameObject);
            }
            
            if (neutralState == 1 && hitNumber >= 3)
            {
               
              FriendSt();
                globalScript.GetComponent<Global>().CubeFriends += 1;
                friendState = 1;
            }

        }

        
    }
    
    
    
    
    

    void Neutral()
    {
        if (globalScript.GetComponent<Global>().CubeFriends >= 3 && neutralState == 0)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            neutralState = 1;
        }
    }

    

    void PlayerNearBy()
    {
        transform.LookAt(thePlayer.transform.position);
        
       
    }

    void Hostile()
    {
        transform.LookAt(thePlayer.transform.position);
     
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        
    }

    void FriendSt()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        globalScript.GetComponent<Global>().RightClickCounter += 5;
        globalScript.GetComponent<Global>().TotalFriends += 1;
        transform.LookAt(thePlayer.transform.position);
    }
    
}
