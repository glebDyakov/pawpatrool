using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class Play : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



public void LoadLvl(){
SceneManager.LoadScene("Main" + PlayerPrefs.GetInt("lvl"));
}

public void SwitchSound(){
Camera.main.gameObject.GetComponent<AudioListener>().enabled = !Camera.main.gameObject.GetComponent<AudioListener>().enabled;
}

public void Restart(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
}

public void Home(){
		SceneManager.LoadScene("Menu");
	}

    /*void Update()
    {
	if(Input.GetMouseButtonDown(0)){
		SceneManager.LoadScene("Main" + PlayerPrefs.GetInt("lvl"));
		print("dsa");
	} 
    }*/
  

}
