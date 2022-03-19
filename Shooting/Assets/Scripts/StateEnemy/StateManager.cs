using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState;
    public Walk WalkState = new Walk();
    public Chase ChaseState = new Chase();
    public Attack AttackState = new Attack();
    public Wait WaitState = new Wait();
    //public Rejoin RejoinState = new Rejoin();
    //public void Awake()
    //{
    //    WalkState = FindObjectOfType<Walk>().GetComponent<Walk>();
    //    ChaseState = FindObjectOfType<Chase>().GetComponent<Chase>();
    //    AttackState = FindObjectOfType<Attack>().GetComponent<Attack>();
    //}
    public void Start()
    {
        currentState = WalkState;

        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchToTheNextState(State nextState)
    {
        currentState.ExitState(this);
        currentState = nextState;
        nextState.EnterState(this);
    }
}
