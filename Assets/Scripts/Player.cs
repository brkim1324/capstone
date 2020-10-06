using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

using UnityEngine;
using Plane = UnityEngine.Plane;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class Player : MonoBehaviour
{
    private Vector3 newPosition;
    public float speed = 10;
    public Transform target;
    public GameObject cube;
    public GameObject sphere;
    public GameObject Pcolor;
    private float _fireRate = 1f;
    private float _canFire = -1f;

    private float recoveryTime = 2f;

    public Camera mainCamera;

    public Transform firePoint;
    public float fireSpoed;

    public float scaleDown;
    public Vector3 scaleChange;
    public Vector3 scaleRecovery;
    public float sizeX;
    public float sizeY;
    public float sizeZ;

    private Renderer rend;

    private Color colorStart = Color.red;
    private Color colorEnd = Color.green;
    private float duration = 4.0f;

    private float originalScale = 1.0f;

    private float loseFormTime = 1.0f;
    private float loseFormInterval = 1.0f;

    public float egoLevel;
    public float increaseEgo;

    public GameObject globalScript;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        egoLevel = 100;
        scaleDown = 4;
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayer();

        if (Input.GetMouseButton(0))
        {
            locatePosition();
            moveToPosition();
        }

        if (Input.GetMouseButton(1) && globalScript.GetComponent<Global>().RightClickCounter > 0)
        {
            fire();
        }

        
        
        

    }


    void FixedUpdate()
    {
        if (Time.time > loseFormTime)
        {
            loseFormTime += Time.time + loseFormInterval;

        }



        if (rend.material.color == Color.red)
        {
            //this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            // float lerp = Mathf.PingPong(Time.time, duration) / duration;
            // rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }


    }

    void ego()
    {
        egoLevel = egoLevel - 1 * Time.deltaTime;
        if (egoLevel <= 95)
        {
            sizeX = 1.0f;
            sizeY = 1.0f;
            sizeZ = 1.0f;
            scaleChange = new Vector3(-sizeX, -sizeY, -sizeZ);
            target.transform.localScale += target.transform.lossyScale - scaleChange;
        }
    }

    public void scaleChangeDown()
    {
        scaleChange = new Vector3(-0.1f, -0.1f, -0.1f);
        target.transform.localScale += scaleChange;
        
    }

    public void scaleRecover()
    {
        scaleRecovery = new Vector3(4.0f, 4.0f, 4.0f);
        target.transform.localScale = scaleRecovery;
    }


    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            newPosition = new Vector3(hit.point.x, 0, hit.point.z);

        }
    }

    void moveToPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);


    }


    void rotatePlayer()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 newPoint = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, newPoint, Color.blue);

            transform.LookAt(new Vector3(newPoint.x, transform.position.y, newPoint.z));
        }
    }

    void fire()
    {
        if (Input.GetMouseButton(1) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(cube, firePoint.position, firePoint.rotation);
        }


    }

    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {

            scaleChange = new Vector3(-sizeX, -sizeY, -sizeZ);
            target.transform.localScale -= scaleChange;
            Destroy(col.collider.gameObject);

        }

        if (col.gameObject.tag == "Sphere")
        {
            scaleChange = new Vector3(sizeX, sizeY, sizeZ);
            target.transform.localScale -= scaleChange;
            Destroy(col.collider.gameObject);
        }

        if (col.gameObject.tag == "EnemyCube")
        {

            //scaleChange = new Vector3(-sizeX, -sizeY, -sizeZ);
            //target.transform.localScale -= scaleChange;
           // originalScale += 1;
           
            
            Destroy(col.collider.gameObject);
            globalScript.GetComponent<Global>().RightClickCounter -= 2;

        }

        if (col.gameObject.tag == "Good")
        {
            scaleChange = new Vector3(-sizeX, -sizeY, -sizeZ);
            target.transform.localScale -= scaleChange;

            Destroy(col.collider.gameObject);
        }
    }

    

}
