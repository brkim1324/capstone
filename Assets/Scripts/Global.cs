using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Serialization;


public class Global : MonoBehaviour
{

    public float CubeFriends;
    public float CapFriends;
    public float TotalFriends;
    public float TotalShapes;

    public float Level_1_Clear;
    public float Level_4_Clear;

    public GameObject BossScript;
    

    public GameObject BadCube;
    public GameObject NeutralCube;
    public Player player;
    

    public float RightClickCounter;
    private float RCCMax = 60.0f;

    public GameObject VictoryText;
    public GameObject ProceedText;
    public float resetDelay;

    public GameObject PlayerCube;
    public GameObject PlayerCap;

    public GameObject WorkCube_1;
    public GameObject WorkCube_2;

    public GameObject WorkCap_1;
    public GameObject WorkCap_2;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        CubeFriends = 0;
        CapFriends = 0;
        RightClickCounter = 30;
        TotalFriends = 0;

        Level_1_Clear = 0;

        WorkCube_1.SetActive(false);
        WorkCube_2.SetActive(false);
        WorkCap_1.SetActive(false);
        WorkCap_2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
      

        if (RightClickCounter >= 60)
        {
            RightClickCounter = 60;
        }

       
        
        Sum();

        
        //Win Conditions

        if (BossScript.GetComponent<BossCap>().pass > 0)
        {
            Win();
        }
        
        
        //

        if (CubeFriends >= 5)
        {
            PlayerCube.SetActive(true);
          
        }

        if (CapFriends >= 5)
        {
            PlayerCap.SetActive(true);
         
        }
        
        
        
        //Level 1//
        if (Level_1_Clear == 1)
        {
            ProceedText.SetActive(true);
        }
        
        //Level_4//
        if (Level_4_Clear == 1)
        {
            
        }
        
        //Level_5//
        
    }

    void Sum()
    {
        TotalFriends = CubeFriends + CapFriends;
       
    }

    void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void Win()
    {
       
            VictoryText.SetActive(true);
        Time.timeScale = 0.5f;
        Invoke("Reset", resetDelay);

    }

    void Reset()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void CubeBonus()
    {
        WorkCube_1.SetActive(true);
        WorkCube_2.SetActive(true);
    }

    public void CapBonus()
    {
        WorkCap_1.SetActive(true);
        WorkCap_2.SetActive(true);
    }
   

   
    
    
}
