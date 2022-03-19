using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State 
{
    // data
    [SerializeField] internal EnemyStats enemyStats;
    [SerializeField] private Animator ani;
    private float timeTemp;
    [Header("Ranged Enemy")]
    [Tooltip("Attached If it's ranged enemy")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform point;
    [SerializeField] private float _projectileSpeed = 20.0f;
    [SerializeField] private int amountOfBulletAWT = 1;
    private Vector3 _deflection;
    [Header("Melee Enemy")]
    [Tooltip("Attached If it's melee enemy")]
    [SerializeField] private float radius;
    [Tooltip("Attached If it's melee enemy")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform centerPoint;
    [Tooltip("Distance")]
    [SerializeField] internal float distance = 3;

    private bool _meleeCharacter = false;
    private float elapsedTime;

    private string _MELEE = "Attack";
    private string _RANGED = "Fire";
    private void Start()
    {
        _meleeCharacter = enemyStats.MeleeEnemy;
        elapsedTime = enemyStats.AttackSpeed;
    }
    public override void EnterState(StateManager state)
    {
        ani.SetBool(keyAni, true);
        speedMove = 0;
        timeTemp = 0;
    }

    public override void ExitState(StateManager state)
    {
        
    }

    public override void UpdateState(StateManager state)
    {
        if (player == null) return;
        if (_meleeCharacter == false)
        {
            if (timeTemp <= 0)
            {
                timeTemp = elapsedTime;
                ani.SetTrigger(_RANGED);
            }
            else
            {
                timeTemp -= Time.deltaTime;
            }
        }
        else
        {
            if (timeTemp <= 0)
            {
                timeTemp = elapsedTime;
                ani.SetTrigger(_MELEE);
                ani.SetBool(keyAni, true);
            }
            else
            {
                timeTemp -= Time.deltaTime;
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position)     > distance)
        { 
            state.SwitchToTheNextState(state.WalkState);
        }
    }
    // event animation
    // ranged enemy
    private void Shooting()
    {
        if (player == null) return;

        Vector3 targetDir = player.transform.position - transform.position;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        _deflection = new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
        for(int i=0;i < amountOfBulletAWT;i++)
        {
            GameObject bulletObject = Instantiate(bullet, centerPoint.position, Quaternion.identity);
            bulletObject.transform.eulerAngles = new Vector3(
                0,
                0,
                Vector3.Angle(targetDir, transform.right)
            ); ;
            bulletObject.GetComponent<Bullet>().GetDamage(enemyStats.Damage, false);
            bulletObject.transform.SetParent(gameObject.transform);
            float rand = Random.RandomRange(-1.8f,1.8f);
            if (enemyStats.BossEnemy == true)
            {
                FindObjectOfType<Bullet>().Movement(direction + new Vector3(rand, 0, 0), _projectileSpeed + rand);
            }
            else
            {
                FindObjectOfType<Bullet>().Movement(direction, _projectileSpeed + rand);
            }
            if (enemyStats.BossEnemy == true)
            {
                Destroy(bulletObject, 2f);
            }
            else {
                Destroy(bulletObject, 0.8f);
            }
        }
    }
    private void AttackMelee()
    {
        if (player == null) return; 

        Collider2D hit = Physics2D.OverlapCircle(centerPoint.position,radius,playerLayer);
        if (hit != null)
        {
            hit.GetComponent<ITakeDamage>().TakeDamage(enemyStats.Damage,false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(centerPoint.position, radius);
    }
}
