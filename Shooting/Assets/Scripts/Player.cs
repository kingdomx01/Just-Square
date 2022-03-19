using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float health;
    [Tooltip("The color will be change when enemy take damage")]
    [SerializeField] private Color32 colorTakeDamage;
    [Tooltip("The color will be change after taking damage for a while")]
    [SerializeField] private Color32 colorDefault;
    [SerializeField] private GameObject body;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject textTakeDamage;
    private HandleItemStats characterData;
    private float healthTemp;
    private bool increaseHealth = false;
    [SerializeField] private TMP_Text healthText;
    public bool IncreaseHealth { set { increaseHealth = value; } }
    private void Awake()
    {
        characterData = FindObjectOfType<HandleItemStats>();
    }
    private void Start()
    {
        healthTemp = health = characterData.Health;
        healthText.text = health.ToString();
        healthBar.maxValue = health;
    }
    private void Update()
    {
        healthBar.value = health;
        //skill
        if (increaseHealth == true)
        {
            float temp;
            temp = healthTemp - health;
            healthBar.maxValue = healthTemp = health = characterData.Health;
            health -= temp;
            increaseHealth = false;
        }
        if (health <= 0)
        {
            health = 0;
            GameManager.Instance.GameOver = true;
            Destroy(gameObject);
        }
        healthText.text ="HP: " + health.ToString();
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

    public void TakeDamage(float damage,bool crit)
    {
        TextPopup.CreatePopup(textTakeDamage,damage.ToString(),this.transform);
        health -= damage;
        ChangeColorWhenTakeDamage(true);
    }
}
