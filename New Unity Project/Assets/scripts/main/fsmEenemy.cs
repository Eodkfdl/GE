using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsmEenemy : MonoBehaviour
{   
    
    public enum State //기본상태,정찰,조사,쫓음 4가지 상태
    {
        Idle,
        Patrol,
        Investigate,
        Chase
    }
    public State state;
    void moveto()

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
