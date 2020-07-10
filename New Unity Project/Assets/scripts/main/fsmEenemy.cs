using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fsmEenemy : MonoBehaviour
{   GameObject temp;
    public int waynum;
    Behavior behavior;
    Vector3 targetpos;
    Animator ani;
    Quaternion targetRot;
    Vector3 dir;
    Vector3 dirXZ;
    void Start()
    {
        
        waynum = 1;

    }
    private void Awake()
    {
        ChangeState(State.idle);
        temp = GameObject.Find("waypoint").transform.GetChild(1).gameObject;

        ani = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        }
    }
    //상태머신
    public enum State
    {
        idle = 0,
        chase = 1,
        gotta= 2 ,
        patroll = 3

    }
    public int prestate;
    public State state;

    private void ChangeState(State state)
    {
        //스테이트에서 나가기전에 마지막으로 실행되는 Exit()함수;
        switch (this.state)
        {
            case State.idle:
                idleExit();
                break;
            case State.chase:
                chaseExit();
                break;
            case State.gotta:
                gottaExit();
                break;
            case State.patroll:
                patrollExit();
                break;
    
        }

        this.state = state;

        //스테이트에서 들어가고나서 처음으로 실행되는 Enter()함수;
        switch (state)
        {
            case State.idle:
                idleEnter();
                break;
            case State.chase:
                chaseEnter();
                break;
            case State.gotta:
                gottaEnter();
                break;
            case State.patroll:
                patrollEnter();
                break;

        }
    }

    private void idleEnter()
    {

    }
    private void idle()
    {
        ChangeState(State.patroll);
    }
    private void idleTrigger(Collider other)
    {

    }
    private void idleTriggerStay(Collider other)
    {

    }
    private void idleExit()
    {

    }


    private void chaseEnter()
    {
    }
    private void chase()
    {
    }
    private void chaseTrigger(Collider other)
    {
    }
    private void chaseExit()
    {
    }




    private void gottaEnter()
    {
    }
    private void gotta()
    {
    }
    private void gottaTrigger(Collider other)
    {
    }
    private void gottaExit()
    {
    }




    private void patrollEnter()
    {
        ani.SetTrigger("idletowalk");
    }
    private void patroll()
    {
       float dis = Vector3.Distance(transform.position, temp.transform.position);
        if (dis > 0.01)
        {
            Vector3 targetpos = temp.transform.position;
           
          
                // 캐릭터를 이동시킨다.
                targetpos.y = transform.position.y;
                transform.localPosition = Vector3.MoveTowards(transform.position, targetpos, 2.0f * Time.deltaTime);

             dir = targetpos - transform.position;
             dirXZ = new Vector3(dir.x, 0, dir.z);
            if (dirXZ.magnitude > 0)
              targetRot = Quaternion.LookRotation(dirXZ);
            if (dirXZ.x < 0.001 || dirXZ.z < 0.001)
            {
                dirXZ = new Vector3(0, 0, 0);
            }
            if (Vector3.Distance(transform.position, targetpos) > 0.2f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 550.0f * Time.deltaTime);

            }
        }
        else { waynum += 1; }
        if(waynum > 14)
        {
            waynum = 1;
        }
    }
    private void patrollTrigger(Collider other)
    {
    }
    private void patrollExit()
    {
       
    }



    void Update()
    {
        //스테이트상태에따라 업데이트
        switch (state)
        {
            case State.idle:
                idle();
                break;
            case State.chase:
                chase();
                break;
            case State.gotta:
                gotta();
                break;
            case State.patroll:
                patroll();
                break;

        }
        //매초실행되야하는거 불러오기

    }
}
