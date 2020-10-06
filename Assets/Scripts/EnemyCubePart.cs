using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubePart : MonoBehaviour
{
    private float time = 2f;

    private Transform target;

    public float speed;
    
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
      
        movePosition();
        
       
  
        
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    
    }

  

    void movePosition()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
