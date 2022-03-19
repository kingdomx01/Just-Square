using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour 
{
    [SerializeField] private int _killedEnemyToSpawnSuperEnemy = 4;
    [SerializeField] private List<Transform> _posSpawn;
    [SerializeField] private List<GameObject> _enemyList;
    [SerializeField] private List<GameObject> _superEnemyList;
    [SerializeField] private GameObject spawnManager;
    [Tooltip("maximum Distance btw player and spawn point neart player position")]
    [SerializeField] private float distance;
    public Transform player;
    [SerializeField] private float timeToSpawn;
    [Tooltip("Amount of enemy survive maximum at once")]
    [SerializeField] private int amountOfEnemy;
    // Amount of enemy have been spawned
    private List<GameObject> enemyObject = new List<GameObject>();
    //store value of random about type enemies
    int randTypeEnemyTemp;
    int randPosSpawnTemp;
    //count down to value timeToSpawn
    float timeToSpawnTemp;
    [SerializeField] private List<GameObject> _SpawnPointNearPlayer = new List<GameObject>();
    public static int amountOfEnemyKilledTemp = 0;
    [SerializeField] private EnemyStats superEnemy;
    // Start is called before the first frame update
    private void Awake()
    {
        //foreach (GameObject pos in spawnManager.GetComponentInChildren<GameObject>().gameObject)
        //{

        //}
        SpawnEnemy(amountOfEnemy,true);
        timeToSpawnTemp = timeToSpawn;
    }
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        RemoveNullVariable();
        //Spawn Enemy if amount of enemy less than required quality
        SpawnEnemyAfterKilled();

    }

    private void SpawnEnemyAfterKilled()
    {
        if (enemyObject.Count < amountOfEnemy)
        {
            SpawnEnemy(Mathf.Abs(enemyObject.Count - amountOfEnemy), false);
            _SpawnPointNearPlayer.Clear();
            FindSpawnPointNearPlayerPosition(distance);
        }
    }

    private void RemoveNullVariable()
    {
        enemyObject.RemoveAll(s => s == null);
    }

    private void FindSpawnPointNearPlayerPosition(float distance)
    {
        foreach (Transform point in _posSpawn)
        {
            if (Vector3.Distance(point.position,player.position) < distance)
            {
                _SpawnPointNearPlayer.Add(point.gameObject);
            }
        }
    }

    private void SpawnEnemy(int amountOfEnemy,bool begin)
    {
        if (begin == true)
        {
            for (int i = 0; i < amountOfEnemy; i++)
            {
                int randTypeEnemy = Random.Range(0, _enemyList.Count);
                enemyObject.Add(Instantiate(_enemyList[randTypeEnemy], _posSpawn[i].position, Quaternion.identity));
            }
        }
        else
        {
            // no spawn point to spawn enemy
            if (_SpawnPointNearPlayer.Count < amountOfEnemy)
            {
                amountOfEnemy -= _SpawnPointNearPlayer.Count;
            }
            if (_SpawnPointNearPlayer.Count == 0)
            {
                amountOfEnemy = 0;
            }
            if (timeToSpawnTemp <= 0)
            {
                for (int i = 0; i < amountOfEnemy; i++)
                {
                    int randTypeEnemy = Random.Range(0, _enemyList.Count);
                    int randTypeSuperEnemy = Random.Range(0, _superEnemyList.Count);
                    int randPos = Random.Range(0, _SpawnPointNearPlayer.Count);
                    if (randPos == randPosSpawnTemp)
                    {
                        randPos = RemovePosSameConsecutively(randPos);
                    }
                    if (amountOfEnemyKilledTemp > _killedEnemyToSpawnSuperEnemy)
                    {
                        GameObject enemyObject = Instantiate(_superEnemyList[randTypeSuperEnemy], _SpawnPointNearPlayer[randPos].transform.position, Quaternion.identity);
                        enemyObject.GetComponent<Attack>().enemyStats = superEnemy;
                        enemyObject.GetComponent<Enemy>().enemyStats = superEnemy;
                        enemyObject.GetComponentInChildren<HealthBar>().StateEnemy = 1;
                        amountOfEnemyKilledTemp = 0;
                        enemyObject.name = "Super Enemy";
                    }
                    else
                    {
                        enemyObject.Add(Instantiate(_enemyList[randTypeEnemy], _SpawnPointNearPlayer[randPos].transform.position, Quaternion.identity));
                    }
                    randPosSpawnTemp = randPos;
                }
                timeToSpawnTemp = timeToSpawn;
            }
            else
            {
                timeToSpawnTemp -= Time.deltaTime;
            } 
        }
    }
    private int RemovePosSameConsecutively(int randPos)
    {
        var exclude = new HashSet<int>() { randPos };
        var range = Enumerable.Range(0, _SpawnPointNearPlayer.Count).Where(i => !exclude.Contains(i));

        var rand = new System.Random();
        int index = rand.Next(0,exclude.Count);
        return index;
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position,distance);
    }
}
