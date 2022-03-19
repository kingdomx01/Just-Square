using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejoin : State
{
    [SerializeField] private float distance = 3;
    public override void EnterState(StateManager state)
    {
        Debug.Log("Rejoin state");
        transform.position = Vector2.MoveTowards(transform.position,location.position, speedMove * Time.deltaTime);
    }

    public override void ExitState(StateManager state)
    {

    }

    public override void UpdateState(StateManager state)
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            state.SwitchToTheNextState(state.ChaseState);
        }
        if (transform.position == location.position)
        {
            state.SwitchToTheNextState(state.WalkState);
        }
    }
}
