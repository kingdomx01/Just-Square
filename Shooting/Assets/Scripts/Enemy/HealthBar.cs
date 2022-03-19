using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyStats[] data;
    [SerializeField] private Slider[] slider;
    [SerializeField] private Vector3 offset;
    private Enemy enemy;
    private int stateEnemy = 0;
    private int _timeHideUi = 6;
    private float _countDown;
    public int StateEnemy
    {
        set { stateEnemy = value; }
        get { return stateEnemy; }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
    }
    void Start()
    {
        _countDown = _timeHideUi;
        slider[stateEnemy].maxValue = data[stateEnemy].Health;
        slider[stateEnemy].gameObject.SetActive(false);
        for (int i = 0; i < stateEnemy; i++)
        {
            if (i == stateEnemy) continue;
            slider[stateEnemy].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider[stateEnemy].transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        slider[stateEnemy].value = enemy.Health;
        if (enemy.IsTakeDamage == true)
        {   
            slider[stateEnemy].gameObject.SetActive(true);
            if (_countDown <= 0)
            {
                slider[stateEnemy].gameObject.SetActive(false);
                _countDown = _timeHideUi;
                enemy.IsTakeDamage = false;
            }
            else
            {
                _countDown -= Time.deltaTime;
            }
        }
    }
}
