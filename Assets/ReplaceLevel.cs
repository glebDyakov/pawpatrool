using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplaceLevel : MonoBehaviour
{
/*void Update()
    {
if(Input.GetMouseButtonDown(0)){
SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
	}
}*/
	void OnMouseDown(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
		print(SceneManager.GetActiveScene().ToString());
	}
}
