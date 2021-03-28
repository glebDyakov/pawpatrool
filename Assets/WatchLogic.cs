using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchLogic : MonoBehaviour
{
	bool sale=true;
	public Text timeText;
	public int second = 0;	
	public GameObject player;
	/*
	public int currentSecond = 0;
	public GameObject watch;
	*/
	
	void Watch(){
		if( /*sale && */int.Parse(timeText.text)<=0){
			CancelInvoke("Watch");
		Play playScript=player.GetComponent<Play>();//.ShowWindow("lose")
		playScript.ShowWindow("lose");
		}else{
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

    void Start()
    {
	//StartCoroutine(WatchTime());        
	//StartCoroutine(WatchTick());    
	InvokeRepeating("Watch", 1f, 1f);    
    }

    void Update()
    {
	    
    }

}
