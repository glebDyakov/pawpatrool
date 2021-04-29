using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenLogic : MonoBehaviour
{
    void Start()
    {
	/*
	PlayerPrefs.DeleteAll();
	PlayerPrefs.Save();
	*/
	Invoke("LoadSelectedCharacterScene", 5f);   
    }
	public void LoadSelectedCharacterScene(){
		SceneManager.LoadScene("Menu");
	}
}
