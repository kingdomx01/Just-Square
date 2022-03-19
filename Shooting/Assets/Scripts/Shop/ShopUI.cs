using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private string keyBoard;
    [SerializeField] private GameObject textKeyBoard;

    private bool toggle = false;

    private GameObject player;
    // check if player is beside the shop 
    private bool _besideShop = false;
    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }
    private void Start()
    {
       
        textKeyBoard.GetComponentInChildren<TMP_Text>().text = "[" + keyBoard + "]";
        textKeyBoard.SetActive(false);
        ShopPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShopPanel.SetActive(false);
        }
        if (_besideShop)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[3]);
                player.GetComponentInChildren<RotationGun>().enabled = toggle;
                player.GetComponent<Shooting>().enabled = toggle;
                ShopPanel.SetActive(!toggle);
                toggle = !toggle;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textKeyBoard.gameObject.SetActive(true);
            _besideShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textKeyBoard.gameObject.SetActive(false);
            _besideShop = false;
            toggle = false;
            ShopPanel.SetActive(false);
        }
    }
}
