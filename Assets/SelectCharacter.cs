using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectCharacter : MonoBehaviour
	
{	public Image bigImg;
	string playableCharacter = "a";
	 public bool lockChoose=true;
	public bool play = false;
	int lvl;
    // Start is called before the first frame update
    void Start()
    {	lvl=PlayerPrefs.GetInt("lvl");
        if(lvl>=int.Parse(Convert.ToString(gameObject.tag[0]))){
		transform.GetChild(0).gameObject.SetActive(false);
		lockChoose=false;
	}
    }

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name=="changeSize" && !lockChoose){
			//gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x - 0.2f, gameObject.transform.localScale.y - 0.2f);
			gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x / 1.4f, gameObject.transform.localScale.y / 1.4f);
		}
		//new Vector3(other.gameObject.transform.localScale.x - 0.05f, other.gameObject.transform.localScale.y - 0.05f, other.gameObject.transform.localScale.z - 0.05f);
	}

	void OnTriggerEnter2D(Collider2D other){
		print("aa");
		if(other.gameObject.name=="changeSize" && !lockChoose){
			//gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x + 0.2f, gameObject.transform.localScale.y + 0.2f);
			gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * 1.4f, gameObject.transform.localScale.y * 1.4f);
			print(other.gameObject.name);
		}
		//new Vector3(other.gameObject.transform.localScale.x + 0.05f, other.gameObject.transform.localScale.y + 0.05f, other.gameObject.transform.localScale.z + 0.05f);
		if(other.gameObject.tag == "Player"){
			/*
			//DontDestroyOnLoad(other.gameObject);
	                SceneManager.LoadScene("Main");
			play = true;
			*/
			//playableCharacter = other.gameObject;
			//playableCharacter = other.gameObject.name;
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }

	/*void OnMouseDown(){
		if(lockChoose){
		playableCharacter = gameObject.name;
		PlayerPrefs.SetString("name",playableCharacter);
		print(PlayerPrefs.GetString("name"));
		}

	}*/
public void clic(){

		if(!lockChoose){
		bigImg.sprite=gameObject.GetComponent<Image>().sprite;
		playableCharacter = gameObject.name;
		PlayerPrefs.SetString("name",playableCharacter);
		print(PlayerPrefs.GetString("name"));
		}
}

}
