using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    // data
    [SerializeField] private EnemyStats enemyStats;
    [Tooltip("Distance to quit running after players")]
    [SerializeField] private float distance = 3;
    [Tooltip("Necessary distance to switch to attack state")]
    private float rangeShoot;
    [SerializeField] internal bool isFacingRight;
    private void Start()
    {
        rangeShoot = enemyStats.AttackRange;
    }
    public override void EnterState(StateManager state)
    {
        ani.SetBool(keyAni, true);
        isFacingRight = state.WalkState.isFacingRight;
        if (distance < state.WalkState.distance)
        {
            distance += Mathf.Abs(distance - state.WalkState.distance);
        }
        speedMove = _speedMoveTemp;
    }

    public override void ExitState(StateManager state)
    {

    }

    public override void UpdateState(StateManager state)
    {
        if (player == null) return; 
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            GetComponent<Animator>().SetBool("Chase", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedMove * Time.deltaTime);
            if (player.transform.position.x > transform.position.x)
            {
                if (isFacingRight == false)
                {
                    Flip();
                    isFacingRight = true;
                }
            }
            else if (player.transform.position.x < transform.position.x)
            {
                if(isFacingRight == true) 
                {
                    Flip();
                    isFacingRight = false;
                }        
            }
            if (Vector3.Distance(transform.position, player.transform.position) < rangeShoot)
            {
                state.SwitchToTheNextState(state.AttackState);
                GetComponent<Animator>().SetBool("Chase",false);
                ani.SetBool(keyAni, true);
            }
        }
        else
        {
            if (enemyStats.BossEnemy == true)
            {
                ani.SetTrigger("Attack_Gun");
            }
            state.SwitchToTheNextState(state.WalkState);
            GetComponent<Animator>().SetBool("Chase", false);
        }
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
