using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
struct Cell
{
    public Store item;
    public GameObject cellGameObject;
}
public class UI_Item_Collected : MonoBehaviour
{
    public const int amountOfCellContain = 7;
    [SerializeField] private GameObject cellContain;
    internal List<Cell> cellList = new List<Cell>();
    private Sprite[] sprites;
    public static int _ItemUpdateText = 0;
    private void Awake()
    {
        sprites = Resources.LoadAll("Spirtes/Item", typeof(Sprite)).Cast<Sprite>().ToArray();
        for (int i = 0; i < amountOfCellContain; i++)
        {
            GameObject cellContainObject = Instantiate(cellContain, transform.position, Quaternion.identity);
            cellContainObject.transform.SetParent(gameObject.transform, false);
            cellContainObject.SetActive(false); ;
            var cell = new Cell();
            cell.cellGameObject = cellContainObject;
            cellList.Add(cell);

        }
    }
    private void Start()
    {
        for (int i = 0; i < Save.Instance.itemCollected.Count; i++)
        {
            var cell = new Cell();
            cell.cellGameObject = cellList[i].cellGameObject;
            cell.item = Save.Instance.itemCollected[i];
            cellList[i] = cell;
            if (cellList[i].item.hasOwned == false) continue;
            cellList[i].cellGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "x" + Save.Instance.itemCollected[i].stack;
            cellList[i].cellGameObject.GetComponent<Image>().sprite = sprites[Save.Instance.itemCollected[i].ID];
            cellList[i].cellGameObject.SetActive(true);
        }
    }
    private void Update()
    {
    }

    public void UpdateAmountOfItemUI(int ID) // Bug
    {
        if (cellList.Any(x => x.item.ID == ID))
        {
            int indexSave = Save.Instance.itemCollected.IndexOf(Save.Instance.itemCollected.Find(x => x.ID == ID));
            int indexCellList = cellList.IndexOf(cellList.Find(x => x.item.ID == ID));
            cellList[indexCellList].cellGameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "x"+Save.Instance.itemCollected[indexSave].stack.ToString();
        }
        else
        {
            for (int i = 0; i < cellList.Count; i++)
            {
                if (cellList[i].cellGameObject.activeSelf == false)
                {
                    var cell = new Cell();
                    cell.cellGameObject = cellList[i].cellGameObject;
                    int index = Save.Instance.itemCollected.IndexOf(Save.Instance.itemCollected.Find(x => x.ID == ID));
                    cell.item.ID = Save.Instance.itemCollected[index].ID;
                    cellList[i] = cell;
                    cellList[i].cellGameObject.GetComponent<Image>().sprite = sprites[ID];
                    cellList[i].cellGameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void SetActiveGameObject()
    {
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i].cellGameObject.GetComponent<Image>().sprite == null)
            {
                cellList[i].cellGameObject.SetActive(false);
            }
        }
    }
    private void OnDestroy()
    {
        cellList.Clear();
    }
    public int GetAmountOfCellContainer()
    {
        return amountOfCellContain;
    }
}
