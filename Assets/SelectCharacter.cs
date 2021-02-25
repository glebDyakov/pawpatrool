using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectCharacter : MonoBehaviour

{
	 string playableCharacter = "a";
	public bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerExit2d(Collider other){
		other.gameObject.transform.localScale = new Vector2(other.gameObject.transform.localScale.x - 0.05f, other.gameObject.transform.localScale.y - 0.05f);
//new Vector3(other.gameObject.transform.localScale.x - 0.05f, other.gameObject.transform.localScale.y - 0.05f, other.gameObject.transform.localScale.z - 0.05f);
	}

	void OnTriggerEnter2d(Collider other){
		other.gameObject.transform.localScale = new Vector2(other.gameObject.transform.localScale.x + 10f, other.gameObject.transform.localScale.y + 0.05f);
		print(other.gameObject.name);
//new Vector3(other.gameObject.transform.localScale.x + 0.05f, other.gameObject.transform.localScale.y + 0.05f, other.gameObject.transform.localScale.z + 0.05f);
		if(other.gameObject.tag == "Player"){
/*
			//DontDestroyOnLoad(other.gameObject);
	                SceneManager.LoadScene("Main");
			play = true;
*/
			
			//playableCharacter = other.gameObject;
			playableCharacter = other.gameObject.name;
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        
    }

	void OnMouseDown(){
		playableCharacter = gameObject.name;
		PlayerPrefs.SetString("name",playableCharacter);
		print(PlayerPrefs.GetString("name"));

	}
}
