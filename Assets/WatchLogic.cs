using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WatchLogic : MonoBehaviour
{
	bool sale=true;
	public Text timeText;
	public static float saleTimeStamp;
	public int second = 0;
	public VideoPlayer videoPlayer;
	public GameObject player;
	/*
	public int currentSecond = 0;
	public GameObject watch;
	*/
	
	void Watch(){
if (!gameObject.active){
		timeText.text="10";
		}
print(timeText.text);
 Player playerScript=player.GetComponent<Player>();
		if( /*sale && */int.Parse(timeText.text)<=0 && playerScript.isPause){
			CancelInvoke("Watch");
			Play playScript=player.GetComponent<Play>();//.ShowWindow("lose")
			playScript.ShowWindow("lose");
			//Time.timeScale=0;
			//saleTimeStamp = Time.timeSinceLevelLoad;
			print("saleTimeStamp: " + saleTimeStamp.ToString());
		}else if (playerScript.isPause){
			timeText.text = (int.Parse(timeText.text) - 1).ToString();
		}
	}
	
	/*
	IEnumerator WatchTick(){
		while(second < 10){
			second++;
			timeText.text = (int.Parse(timeText.text) - 1).ToString();
			if(second >= 10){
				//показываем окно проигрыша
			}
			yield return new WaitForSeconds(1f);
		}
	}
	*/
	/*
	IEnumerator WatchTime(){
		while(currentSecond < 60){
			currentSecond++;
			if(currentSecond < 60){
				watch.GetComponent<Image>().fillAmount -= 0.016f;
			}
			yield return new WaitForSeconds(1f);
		}
	} 
	*/

	public void LoseWindow (VideoPlayer source){
		if(!source.isPlaying){
			Time.timeScale=1;
			Play playScript = player.GetComponent<Play>();//.ShowWindow("lose")
			Play.chooseSale = "lose";
			playScript.ShowWindow("lose");
			//playScript.ShowLoseWindow();
			print("end video");		
			//playScript.ShowWindow("lose");
		}
	}

    void Start()
    {
	
	
	videoPlayer.loopPointReached += LoseWindow; // loopPointReached is the event for the end of the video  
	//InvokeRepeating("Watch", 1f, 1f);  
	  
    }

    void Update()
    {
	    
    }

}
