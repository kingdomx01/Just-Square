using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 2;
    private float _startPosX;
    private float _endPos;
    private bool _moveRight;
    [Tooltip("Distance to chase")]
    [SerializeField] internal float distance = 3;
    [SerializeField] internal bool isFacingRight;

    public override void EnterState(StateManager state)
    {
        ani.SetBool(keyAni, true);
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPosX = transform.position.x;
        _endPos = _startPosX + UnitsToMove;
        isFacingRight = state.ChaseState.isFacingRight;
    }

    public override void ExitState(StateManager state)
    {
   
    }

    public override void UpdateState(StateManager state)
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            if (_moveRight == true)
            {
                transform.Translate(speedMove * Time.deltaTime * Vector2.right);
                if (isFacingRight == false)
                {
                    Flip();
                    isFacingRight = true;
                }
            }
            if (enemyRigidBody2D.position.x >= _endPos)
                _moveRight = false;

            if (_moveRight == false)
            {
                transform.Translate(speedMove * Time.deltaTime * -Vector2.right);
                if (isFacingRight == true)
                {
                    Flip();
                    isFacingRight = false;
                }
            }
            if (enemyRigidBody2D.position.x <= _startPosX)
                _moveRight = true;
        }
        else
        {
            state.SwitchToTheNextState(state.ChaseState);
        }
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
