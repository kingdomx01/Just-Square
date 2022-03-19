using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemiesOFEachLevel
{
    public string name;
    public EnemyStats[] data;
}
public class LevelOfDifficultGame : MonoBehaviour
{
    [SerializeField] private GameObject[] levelUI;
    [SerializeField] private List<EnemiesOFEachLevel> levelPhase;
    [SerializeField] private int[] amountOfEnemieRequired = new int[5];
    [SerializeField] private int level = 1;
    public static int amountOfEnemiesKilled = 0;
    int healthTemp;
    bool check = false;
    void Start()
    {
        level = 1;
        for (int i=0;i < levelUI.Length;i++) 
        {
            levelUI[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfEnemiesKilled >= amountOfEnemieRequired[0])
        {
            level = 1;
            levelUI[0].SetActive(true);
        }
        if(amountOfEnemiesKilled >= amountOfEnemieRequired[1])
        {
            levelUI[1].SetActive(true);
            level = 2;
        }
        if(amountOfEnemiesKilled >= amountOfEnemieRequired[2])
        {
            levelUI[2].SetActive(true);
            level = 3;
        }
        if(amountOfEnemiesKilled >= amountOfEnemieRequired[3])
        {
            levelUI[3].SetActive(true);
            level = 4;
        }
        if (amountOfEnemiesKilled >= amountOfEnemieRequired[4])
        {
            amountOfEnemiesKilled++;
            levelUI[4].SetActive(true);
            level = 5;
        }
        //switch (level)
        //{
        //    case 1:
        //        {
        //            for (int i=0;i < levelPhase.Count;i++)
        //            {
        //                if (levelPhase[i].name == "Witch")
        //                {

        //                }else if (levelPhase[i].name == "Demon")
        //                {

        //                }else if (levelPhase[i].name == "Ghost")
        //                {
        //                    FindObjectOfType<Attack>().enemyStats = levelPhase[i].data[0];
        //                }
        //            }
        //            level = 0;
        //            break;
        //        }
        //    case 2:
        //        {
        //            for (int i = 0; i < levelPhase.Count; i++)
        //            {
        //                if (levelPhase[i].name == "Witch")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Demon")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Ghost")
        //                {
        //                    FindObjectOfType<Attack>().enemyStats.Health = levelPhase[i].data[1].Health;
        //                }
        //            }
        //            level = 0;
        //            print("Level 2");
        //            break;
        //        }
        //    case 3:
        //        {
        //            for (int i = 0; i < levelPhase.Count; i++)
        //            {
        //                if (levelPhase[i].name == "Witch")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Demon")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Ghost")
        //                {
        //                    FindObjectOfType<Attack>().enemyStats = levelPhase[i].data[2];
        //                }
        //            }
        //            level = 0;
        //            print("Level 3");
        //            break;
        //        }
        //    case 4:
        //        {
        //            for (int i = 0; i < levelPhase.Count; i++)
        //            {
        //                if (levelPhase[i].name == "Witch")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Demon")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Ghost")
        //                {
        //                    FindObjectOfType<Attack>().enemyStats = levelPhase[i].data[3];
        //                }
        //            }
        //            level = 0;
        //            print("Level 4");
        //            break;
        //        }
        //    case 5:
        //        {
        //            for (int i = 0; i < levelPhase.Count; i++)
        //            {
        //                if (levelPhase[i].name == "Witch")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Demon")
        //                {

        //                }
        //                else if (levelPhase[i].name == "Ghost")
        //                {
        //                    FindObjectOfType<Attack>().enemyStats = levelPhase[i].data[4];
        //                }
        //            }
        //            level = 0;
        //            print("Level 5");
        //            break;
        //        }
        //    default:
        //        level = 0;
        //        break;
        //}
    }
}
