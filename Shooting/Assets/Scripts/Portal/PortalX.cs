using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalX : MonoBehaviour
{
    [Header("INFORMATION")]
    [SerializeField] private string namePortal;
    [SerializeField] private string nameSceenWillCome;
    [SerializeField] private string keyBoard;
    [Header("PREFABS")]
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textKeyBoard;
    [SerializeField] private Animator ani;
    [SerializeField] private Text notification;
    [Header("OPTION")]
    [SerializeField] private bool _canClosed;
    [SerializeField] private float _timeToClosed;
    [Space(5)]
    [SerializeField] private bool _haveRequires;
    [SerializeField] private int[] ID_ItemRequest;
    [Header("Sound Effect")]
    [SerializeField] private AudioClip sound;
    [Tooltip("Apply if variable _canClosed is check")]
    private bool _besidePortal = false;
    private float timeCountDown;
    private void Start()
    {
        timeCountDown = _timeToClosed;
        ani = ani.GetComponent<Animator>();
        textName.text = namePortal;
        textKeyBoard.text = "[" + keyBoard + "]";
        textKeyBoard.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (timeCountDown > 0)
        {
            timeCountDown -= Time.deltaTime;
        }
        else
        {
            timeCountDown = 0;
        }
        if (_canClosed)
        {
            StartCoroutine(ClosedPortal(_timeToClosed));
            textName.text = namePortal + "(00:" + (Mathf.RoundToInt(timeCountDown)) + ")";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_haveRequires == false)
            {
                if (_besidePortal == true)
                {
                    ani.SetTrigger("FadeOut");
                }
            }
            else
            {
                List<int> check = new List<int>();
                for (int i =0;i < ID_ItemRequest.Length;i++)
                {
                    if (Save.Instance.itemCollected[ID_ItemRequest[i]].hasOwned == false)
                    {
                        check.Add(i);
                    }
                }
                if (check.Count > 0)
                {
                    foreach (int index in check)
                    {
                        notification.text = "Missing item " + Save.Instance.itemCollected[index].name;
                    }
                }
                else
                {
                    if (_besidePortal == true)
                    {
                        ani.SetTrigger("FadeOut");
                    }
                }
            }
        }
    }
    // event in animation
    private void SwitchScreen()
    {
        FindObjectOfType<Save>().SaveMethod();
        SceneManager.LoadScene(sceneName: nameSceenWillCome);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textKeyBoard.gameObject.SetActive(true);
            _besidePortal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textKeyBoard.gameObject.SetActive(false);
            _besidePortal = false;
        }
    }
    private IEnumerator ClosedPortal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ani.SetTrigger("Close");
    }
    // event in animation
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void PlaySoundEffect()
    {
        SoundManager.Instance.audioSource.PlayOneShot(sound);
    }
}
