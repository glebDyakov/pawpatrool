using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchLogic : MonoBehaviour
{
	public int currentSecond = 0;
	public GameObject watch;

	IEnumerator WatchTime(){
		while(currentSecond < 60){
			currentSecond++;
			if(currentSecond < 60){
				watch.GetComponent<Image>().fillAmount -= 0.016f;
			}
			yield return new WaitForSeconds(1f);
		}
	} 
	
    void Start()
    {
	StartCoroutine(WatchTime());        
    }

    void Update()
    {
	        
    }
}
