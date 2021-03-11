using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLogic : MonoBehaviour
{
public int scrollSpeed=1000;
public float minpos;
public float maxpos;
public GameObject scroll;
public bool arrow=true;
    // Start is called before the first frame update
    void Start()
    {
//        minpos=maxpos * -1;
    }

    // Update is called once per frame
    void Update()
    {
if(minpos!=0){
        if(scroll.transform.position.x>=minpos){
	arrow=false;
	}
else{
arrow=true;
}
}
if(maxpos!=0){
        if(scroll.transform.position.x<=maxpos){
	arrow=false;
	}
else{
arrow=true;
}
}
transform.GetChild(0).gameObject.SetActive(arrow);
transform.GetChild(1).gameObject.SetActive(!arrow);
    }

    public void ArrowClick(){
	if(arrow){
	scroll.transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
	
	}
	
	
}
}
