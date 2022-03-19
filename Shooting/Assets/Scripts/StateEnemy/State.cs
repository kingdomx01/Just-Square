using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [Tooltip("Speed of movement")]
    [SerializeField] protected float speedMove = 1;
    [SerializeField] protected string keyAni;
    protected float _speedMoveTemp;
    protected GameObject player;
    protected Transform location;
    protected Animator ani;
    public abstract void EnterState(StateManager state);
    public abstract void UpdateState(StateManager state);
    public abstract void ExitState(StateManager state);
    private void Awake()
    {
        ani = GetComponent<Animator>();
        _speedMoveTemp = speedMove;
        player = FindObjectOfType<Player>().gameObject;
    }
    private void Update()
    {
        if (player == null) return;
    }
}
