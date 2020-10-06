using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
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

    public float PColor_Degree = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, PlayerDistance.position);
        if (distance <= 10)
        {
            PlayerNearBy();
        }
      
        
    }
    
    void FixedUpdate()
    {
        //myRB.velocity = (transform.forward * moveSpeed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
           
            scaleChange = new Vector3(-sizeX,-sizeY,-sizeZ);
            target.transform.localScale -= scaleChange;
            Destroy(col.collider.gameObject);
            
        }

        if (col.gameObject.tag == "Sphere")
        {
            scaleChange = new Vector3(sizeX,sizeY,sizeZ);
            target.transform.localScale -= scaleChange;
            Destroy(col.collider.gameObject);
        }

        if (col.gameObject.tag == "PColor")
        {
            PColor_Degree += 1;
            Destroy(col.collider.gameObject);
            
            if (PColor_Degree >= 3)
            {
                
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                
                PlayerNearBy();
                
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
        
        if (Time.time > _canFire)
        {
            _canFire = Time.time + fireSpeed;
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
    }
}
