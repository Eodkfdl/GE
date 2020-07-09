using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OperateEnter();
    void OperateUpdate();
    void OperateExit();
}

public class StateMachine
{
    //현재 상태를 담는 프로퍼티.
    public IState CurrentState { get; private set; }

    //기본 상태를 생성시에 설정하게 생성자 만들기.
    public StateMachine(IState defaultState)
    {
        CurrentState = defaultState;
    }

    //외부에서 현재상태를 바꿔주는 부분.
    public void SetState(IState state)
    {
        //같은 행동을 연이어서 세팅하지 못하도록 예외처리.
        //예를 들어, 지금 점프중인데 또 점프를 하는 무한점프 버그를 예방할수도 있다.
        if (CurrentState == state)
        {
            Debug.Log("현재 이미 해당 상태입니다.");
            return;
        }

        //상태가 바뀌기 전에, 이전 상태의 Exit를 호출한다.
        CurrentState.OperateExit();

        //상태 교체.
        CurrentState = state;

        //새 상태의 Enter를 호출한다.
        CurrentState.OperateEnter();
    }

    //매프레임마다 호출되는 함수.
    public void DoOperateUpdate()
    {
        CurrentState.OperateUpdate();
    }
}

public class stateidle : IState
{
    Behavior behavior;
    public void OperateEnter()
    {
        
    }

    public void OperateExit()
    {

    }

    public void OperateUpdate()
    {

    }
}
public class statepatroll : IState
{
    Behavior behavior;
    public void OperateEnter()
    {
        // 가장 근처에있는 웨이포인트를 찾아서 넣는다 근처에 없다면 마지막 기억했던 웨이포인트로 돌아가기
    }

    public void OperateExit()
    {
        // 마지막 웨이포인트 기억하기
    }

    public void OperateUpdate()
    {
        
        // 웨이포인트 따라가면서 지점도착하면 다음웨이포인트로 넘어간다 

    }
}
public class statechase : IState
{
    Behavior behavior;
    public void OperateEnter()
    {
        //화들짝놀라는 에니메이션 

    }

    public void OperateExit()
    {
        // 아이들 상태로 돌아간다

    }

    public void OperateUpdate()
    {
        //약 5초간 쫓아가며 5초이후이거나 일정거리가 멀어진다면 상태에서 나온다.

    }
}
public class fsmEenemy : MonoBehaviour
{   GameObject temp;
    public int waynum;
    
    Vector3 targetpos;
    private StateMachine stateMachine;
    private Dictionary<State, IState> dicState = new Dictionary<State, IState>();

    IState idle = new stateidle();
    IState patrol = new stateidle();
    IState gotta = new stateidle();
    IState chase = new stateidle();
    public enum State //기본상태,정찰,조사,쫓음 4가지 상태
    {
        idle,
        patrol,
        chase,
        gotta
    }
   
    void Start()
    {
        dicState.Add(State.idle, idle);
        dicState.Add(State.chase, chase);
        dicState.Add(State.gotta, gotta);
        dicState.Add(State.patrol, patrol);

        //기본상태는 달리기로 설정.
        stateMachine = new StateMachine(idle);

        waynum = 0;
        temp = GameObject.FindWithTag("Waypoint").transform.GetChild(waynum).gameObject;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stateMachine.SetState(dicState[State.gotta]);
        }
    }

    void Update()
    {
        //매초실행되야하는거 불러오기
        stateMachine.DoOperateUpdate();
        
    }
}
