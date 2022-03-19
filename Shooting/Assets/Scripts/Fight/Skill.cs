using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private GameObject body;
    [SerializeField] private float force_Skill_1 = 10;
    [SerializeField] private float timebtwTimes_1;
    [SerializeField] private Image countDownUi_1;
    [SerializeField] private GameObject shieldGameObject;
    [SerializeField] private float timebtwTimes_2;
    [SerializeField] private float timeShield;
    [SerializeField] private Image countDownUi_2;
    private float timeTemp_1;
    private bool isCountDown_1 = false;
    private float timeTemp_2;
    private bool isCountDown_2 = false;
    private void Awake()
    {
    }
    private void Start()
    {
        countDownUi_1.fillAmount = 0;
        countDownUi_2.fillAmount = 0;
        timeTemp_1 = 0;
        timeTemp_2 = 0;
        shieldGameObject.SetActive(false);
    }
    private void Update()
    {
        // Skill 1
        CountDownDashSkill();
        // Skill 2
        CountDownShieldSkill();
    }

    private void CountDownShieldSkill()
    {
        if (timeTemp_2 > 0 && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FlickerUI(countDownUi_2));
        }
        if (timeTemp_2 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(ShieldSkill());
                timeTemp_2 = timebtwTimes_2;
                isCountDown_2 = true;
            }
        }
        else
        {
            timeTemp_2 -= Time.deltaTime;
        }
        if (isCountDown_2)
        {
            // delay timebtwTimes_1 (s)
            countDownUi_2.fillAmount += 1.0f / timebtwTimes_2 * Time.deltaTime;
            if (countDownUi_2.fillAmount >= 1)
            {
                countDownUi_2.fillAmount = 0;
                isCountDown_2 = false;
            }
        }
    }

    private IEnumerator ShieldSkill()
    {
        shieldGameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Shield").GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(timeShield);
        GameObject.FindGameObjectWithTag("Shield").GetComponent<Animator>().SetTrigger("Finish");
    }
    //event in animation
    public void TurnOffShield()
    {
        shieldGameObject.SetActive(false);
    }
    private void CountDownDashSkill()
    {
        if (timeTemp_1 > 0 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(FlickerUI(countDownUi_1));
        }
        if (timeTemp_1 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(DashSkill(body.transform.localScale.x > 0));
                timeTemp_1 = timebtwTimes_1;
                isCountDown_1 = true;
            }
        }
        else
        {
            timeTemp_1 -= Time.deltaTime;
        }
        if (isCountDown_1)
        {
            // delay timebtwTimes_1 (s)
            countDownUi_1.fillAmount += 1.0f / timebtwTimes_1 * Time.deltaTime;
            if (countDownUi_1.fillAmount >= 1)
            {
                countDownUi_1.fillAmount = 0;
                isCountDown_1 = false;
            }
        }
    }

    private IEnumerator DashSkill(bool faceright)
    {
        if (faceright)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(force_Skill_1, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-force_Skill_1, 0);
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    private IEnumerator FlickerUI(Image image)
    {
        image.color = new Color32(99, (byte)countDownUi_1.color.g, (byte)countDownUi_1.color.b,180);
        yield return new WaitForSeconds(0.2f);
        image.color = new Color32((byte)countDownUi_1.color.r, (byte)countDownUi_1.color.g, (byte)countDownUi_1.color.b, 114);
    }
}
