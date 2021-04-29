using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class Play : MonoBehaviour
{
	public AudioSource audioSource;
	public GameObject joystick;
	public GameObject jumpButton;
	public GameObject pauseButton;
	public GameObject timeButton;
	public GameObject coinButton;
//
	public static string chooseSale="";
	public Text timeText;
	public Text saleText;
	public GameObject video;
	public GameObject pause;
	public GameObject loseWindow;
	public GameObject loseScaleWindow;
	public GameObject readyWindow;
	public AudioSource TimerAudio;
	
    // Start is called before the first frame update
    void Start()
    {
	
    }

    // Update is called once per frame



public void LoadLvl(){
	if(PlayerPrefs.GetInt("lvl") > 0){
		SceneManager.LoadScene("Main" + PlayerPrefs.GetInt("lvl"));
	} else if(PlayerPrefs.GetInt("lvl") <= 0){
		PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
		SceneManager.LoadScene("Main" + PlayerPrefs.GetInt("lvl"));
	}
}

public void SwitchSound(){
	//Camera.main.gameObject.GetComponent<AudioListener>().enabled = !Camera.main.gameObject.GetComponent<AudioListener>().enabled;
	audioSource.mute = !audioSource.mute;
	audioSource.enabled = false;
	audioSource.enabled = true;
	/*
	if(audioSource.volume <= 0.0f){
		audioSource.volume = 1.0f;
	} else if(audioSource.volume >= 1.0f){
		audioSource.volume = 0.0f;
	}
	*/
}

public void Restart(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
}

public void Home(){
		SceneManager.LoadScene("Menu");
	}

   
  
	public void ShowWindow(string sale){
		TimerAudio=gameObject.GetComponents<AudioSource>()[2];
		TimerAudio.Stop();
		//timeText.text = "0";
		chooseSale=sale;
		loseScaleWindow.SetActive(false);
		readyWindow.SetActive(true);
		saleText.text="10";
		Time.timeScale=0;
		GetComponent<Player>().timeMultiplier++;
	}

	public void ShowLoseWindow(){
		
		readyWindow.SetActive(false);
		//loseWindow.SetActive(true);
		video.SetActive(true);
		ReclaimReward();
	} 
	public void ReclaimReward()
	    {//Play play=player.GetComponent<Play>();
	
		video.SetActive(false);
		 Player/*GameObject*/ playerScript=gameObject.GetComponent<Player>();
		playerScript.isPause=!playerScript.isPause;
		print("chooseSale " + Play.chooseSale.ToString());
		print("im called from video");
		if(Play.chooseSale=="lose"){
		print("lose");
		playerScript.loseMusic();
		loseWindow.SetActive(true);
		playerScript.windowTxt.gameObject.SetActive(!playerScript.isPause);
		playerScript.windowTxt.text = Convert.ToString (playerScript.count +"/"+playerScript.maxCount);
	}else if(Play.chooseSale=="win"){
		print("win");
		//playerScript.Pause(pause,"pause");
		joystick.SetActive(true);
		jumpButton.SetActive(true);
		pauseButton.SetActive(true);
		timeButton.SetActive(true);
		coinButton.SetActive(true);
		playerScript.time += 50f;
		//playerScript.time = 45f;
		playerScript.showingReclam = true;
		playerScript.bonus = true;
		print("playerScript.showingReclam " + playerScript.showingReclam);
		//timeText.text = "00:45";
		//playerScript.time = Time.timeSinceLevelLoad+45f;
	
		//playerScript.time=180f;
		print(playerScript.isPause);

		print("смотрим рекламу");
	        //coints = Convert.ToString(playerScript.time);
	        //cointsText.text = coints.ToString();
		timeText.text=Convert.ToString(playerScript.time);
		chooseSale="";
		Time.timeScale=1;
	
	}    	
    }

}
