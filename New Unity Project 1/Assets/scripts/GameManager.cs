using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public static GameManager instance;
	private void Awake() 
	{
		if(GameManager.instance != null)
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
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;

	//references to player

	public Player player;
	//public weapon

		public FloatingTextManager floatingTextManager;

	//Logic

	public int cash;
	public int experience;

	//floating tet 
	public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration )
	{
		floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
	}

	//savestate

	public void SaveState()
	{
		string s = "";
		s += "0" + "|";
		s += cash.ToString() + "|";
		s += experience.ToString() + "|";
		s += "0";

		PlayerPrefs.SetString("SaveState", s);
		
		
	}
	//loadstate
	public void LoadState(Scene s, LoadSceneMode mode)
	{
		if (!PlayerPrefs.HasKey("SaveState"))
			return;

		string[] data = PlayerPrefs.GetString("SaveState").Split('|');

		//change player skin
		cash = int.Parse(data[1]);
		experience = int.Parse(data[2]);
		//change weapon level
		
		Debug.Log("Load State");
	}
}
