using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger2 : MonoBehaviour
{
    public GameObject globalScript;
    public GameObject player;
    public Transform SpawnPoint;
    public GameObject BottomText;
    public GameObject NextBottomText;

    
    
    // Start is called before the first frame update
    void Start()
    {
        globalScript.GetComponent<Global>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        
        player.transform.position = SpawnPoint.transform.position;
        globalScript.GetComponent<Global>().Level_1_Clear = 0;
        BottomText.SetActive(false);
        NextBottomText.SetActive(true);

        if (globalScript.GetComponent<Global>().CubeFriends >= 5)
        {
            globalScript.GetComponent<Global>().CubeBonus();
        }

        if (globalScript.GetComponent<Global>().CapFriends >= 5)
        {
            globalScript.GetComponent<Global>().CapBonus();
        }
        
        // if (globalScript.GetComponent<Global>().CubeFriends >= 5 || globalScript.GetComponent<Global>().CapFriends >= 5 ||globalScript.GetComponent<Global>().TotalFriends >= 5)
        //  {
        //     player.transform.position = SpawnPoint.transform.position;
        // }
        
        // if (other.gameObject.tag == "Player" && globalScript.GetComponent<Global>().TotalFriends <= 0)
        // {
        //     globalScript.GetComponent<Global>().RightClickCounter -= 20;
        // }
        
        // if (other.gameObject.tag == "Player" && globalScript.GetComponent<Global>().TotalFriends >= 5)
        //  {
        //     globalScript.GetComponent<Global>().RightClickCounter += 10;
        // }
        
        

        Destroy(this);
    }
}
