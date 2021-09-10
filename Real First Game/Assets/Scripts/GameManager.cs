using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        if (GameManager.instance != null)
        {    
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    //resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponsSprites;
    public List<int> weaponPrice;
    public List<int> xpTable;

    // Refrences
    public Player player;
    //public weapon weapon...
    public FloatingTextManager floatingTextManager;

    // Logic
    public int gold;
    public int experience;

    //Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    /*
     * int perfered skin
     * int gold
     * int exp
     * int weaponLevel
     */
    //Loading and Saving your game
    public void SaveState()
    {
        string s = "";
        s += "0 " + "|";
        s += gold.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {         
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change player skin
        //Amount of Gold
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        
        Debug.Log("LoadState");
    }

}
