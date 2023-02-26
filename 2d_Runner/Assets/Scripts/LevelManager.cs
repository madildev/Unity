using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject[] MenuItems; 
    private int CurrentLevel;
    public static LevelManager instance;
    private LevelManager(){}
    private void Awake() 
    {
       if(instance == null)
       {
          instance = this;
       }
       else
       {
        Destroy(instance);
       }
      this.DisableAllLevels();
      HideScoreBoard();
    }
    public void DisableAllLevels()
    {
        foreach (var Level in this.Levels)
        {
            Level.SetActive(false);
        }
    }

    public void HideMainMenu()
    {
       MenuItems[0].SetActive(false);
    }
    public void HideScoreBoard()
    {
       MenuItems[2].SetActive(false);
    }
    
    public void ShowScoreBoard()
    {   
       MenuItems[2].SetActive(true);
    }

    public void LoadNextLevel()
    {
       HideMainMenu();
       ShowScoreBoard();
       if(CurrentLevel < Levels.Length)
       {
         this.DisableAllLevels();
         Levels[CurrentLevel].SetActive(true);
         CurrentLevel++;
       }
    }
}
