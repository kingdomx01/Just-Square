using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [Tooltip("Amount of enemy required open the chest")]
    [SerializeField] private int numberRequired;
    public static int enemyKilled = 0;
    [SerializeField] private Text notificationText;
    [SerializeField] private GameObject item;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enemyKilled >= numberRequired)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    GetComponent<Animator>().SetBool("Open", true);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.E))
                {
                    StartCoroutine(notification());
                }
            }
        }
    }
    IEnumerator notification()
    {
        notificationText.text = "You need to kill " + Mathf.Abs(enemyKilled - numberRequired) + " more enemies";
        yield return new WaitForSeconds(1.5f);
        notificationText.text = "";
    }
    public void CreateItem()
    {
       GameObject itemObject = Instantiate(item,transform.position,Quaternion.identity);
        itemObject.GetComponent<Rigidbody2D>().AddForce(150 * Vector2.up, ForceMode2D.Force);
    }
}
