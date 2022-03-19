using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : State
{
    [SerializeField] private float timeWaitToSwitchState = 1;
    [Tooltip("Distance to switch to Attack state")]
    [SerializeField] private float distance;
    private float _timeTemp;

    public override void EnterState(StateManager state)
    {
        _timeTemp = timeWaitToSwitchState;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public override void ExitState(StateManager state)
    {
        ani.SetBool(keyAni,false);
    }

    public override void UpdateState(StateManager state)
    {
        if (_timeTemp <= 0)
        {
            state.SwitchToTheNextState(state.WalkState);
            _timeTemp = timeWaitToSwitchState;
        }
        else
        {
            ani.SetBool(keyAni, true);
            _timeTemp -= Time.deltaTime;
            speedMove = 0;
        }
    }
}
