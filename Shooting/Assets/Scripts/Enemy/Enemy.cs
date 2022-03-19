using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] internal EnemyStats enemyStats;
    [SerializeField] private GameObject coinGameObject;
    [SerializeField] private GameObject textTakeDamage;
    [SerializeField] private GameObject textTakeDamageCrit;
    public float health;
    private int coinDrop;
    private bool isTakeDamage;
    public bool IsTakeDamage { get { return isTakeDamage; } set { isTakeDamage = value; } }

    public float Health
    {
        get { return health; }
    }
    [Tooltip("The color will be change when enemy take damage")]
    [SerializeField] private Color32 colorTakeDamage;
    [Tooltip("The color will be change after taking damage for a while")]
    [SerializeField] private Color32 colorDefault;
    //Destroy gameobject if distance x-axis btw player and enemy is too far
    private float distanceX = 25;
    //Destroy gameobject if distance y-axis btw player and enemy is too far"
    private float distanceY = 8;
    [SerializeField] private GameObject body;
    private bool _meleeCharacter = false;
    private Animator ani;
    private GameObject player;
    bool setHealth1Time = true;
    public GameObject Body 
    {
        get { return body; }
    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = enemyStats.Health;
        coinDrop = enemyStats.CoinDrop;
        _meleeCharacter = enemyStats.MeleeEnemy;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if (Vector3.Distance(player.transform.position,gameObject.transform.position) > distanceX)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(player.transform.position.y-gameObject.transform.position.y) > distanceY)
        {
            Destroy(gameObject);
        }
        if (health <= 0)
        {
            Dead();
        }
    }
    public void ChangeColorWhenTakeDamage(bool changeColor)
    {
        if (changeColor == true)
        {
            body.GetComponent<SpriteRenderer>().color = colorTakeDamage;
            Invoke("ChangeColorToDefault", 0.15f);
        }
    }
    // The color of enemy will be change after taking damage for a while
    private void ChangeColorToDefault()
    {
        body.GetComponent<SpriteRenderer>().color = colorDefault;
    }

    private void Dead()
    {
        if (enemyStats.MeleeEnemy == true)
        {
            ani.SetBool("Die", true);
            GetComponent<Rigidbody2D>().simulated = false;
        }
        else if (enemyStats.BossEnemy == true)
        {
            ani.SetBool("Die", true);
        }
        else
        {
            DestroyGameObject();
        }
    }
    // event in animation
    private void DestroyGameObject()
    {
        for (int i = 0;i < coinDrop;i++)
        {
            GameObject coin = Instantiate(coinGameObject,gameObject.transform.position,Quaternion.identity);
            float randomForce = Random.RandomRange(-0.3f,0.3f);
            coin.GetComponent<Rigidbody2D>().AddForce(transform.position * randomForce,ForceMode2D.Impulse) ;  
        }
        if (enemyStats.DropItem)
        {
            if (Random.Range(0, 100) <= enemyStats.ItemDropRate)
            {
                for (int i = 0; i < enemyStats.ItemDrop.Count; i++)
                {
                    GameObject item = Instantiate(enemyStats.ItemDrop[i], gameObject.transform.position, Quaternion.identity);
                    item.name = transform.name.Replace("(clone)", "").Trim();
                }
            }
        }
        Spawn.amountOfEnemyKilledTemp++;
        LevelOfDifficultGame.amountOfEnemiesKilled++;
        Chest.enemyKilled++;
        Destroy(gameObject);
    }
    public void TakeDamage(float damage,bool crit)
    {
        if (crit == true)
        {
            TextPopup.CreatePopup(textTakeDamageCrit, damage.ToString(), this.transform);
        }
        else
        {
            TextPopup.CreatePopup(textTakeDamage, damage.ToString(), this.transform);
        }
        health -= damage;
        isTakeDamage = true;
        ani.SetTrigger("TakeDamage"); 
        ChangeColorWhenTakeDamage(true);
    }
    // event in animation
}