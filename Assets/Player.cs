using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//using UnityEngine.Random;
//using System.Random;

public class Player : MonoBehaviour
{
public Joystick joystick;
public Button volumeBtn;
public Button jmpBtn;
public Button pauseBtn;
float moveV;
float moveH;
public bool isPause=false;
Vector3 moveInput;
Vector3 moveVelocity;
public float time=180f;
Vector3 rot;
public GameObject win;
public GameObject lose;
public GameObject sale;
public GameObject[] dogs;
public int jumpforce;
public float speed = 5f;
public Text timeText;
public Animator anim;
string startTime;
public Text txt;
public Text windowTxt;
 int lvl=1;
public int maxCount=3;
int count=0;
public bool yetJump = false;
Rigidbody rb;
public string flag="";
Vector3 m_EulerAngleVelocity = new Vector3(0, 100, 0);
Vector3 m_EulerAngleVelocity2 = new Vector3(0, -100, 0);
public List<AudioClip> clips;
AudioSource audio;
AudioSource TimerAudio;
AudioSource MainAudio;

    // Start is called before the first frame update
void Awake(){
audio=GetComponents<AudioSource>()[0];
MainAudio=GetComponents<AudioSource>()[1];
TimerAudio=GetComponents<AudioSource>()[2];
}

    void Start()
    {



PlayerPrefs.SetInt("lvl",lvl);
Time.timeScale=1;
/*if(lvl != null)
PlayerPrefs.SetInt("lvl",lvl);
else*/
if(PlayerPrefs.HasKey("lvl"))
 lvl=PlayerPrefs.GetInt("lvl");
else
PlayerPrefs.SetInt("lvl",lvl);
maxCount=lvl*5;
maxCount=1;
print(lvl);



if (flag != ""){
	PlayerPrefs.SetString("name",flag);
	}
PlayerPrefs.SetString("name",dogs[lvl-1].name);
	//anim = GetComponent<Animator>();
	rb = GetComponent<Rigidbody>();
	foreach(GameObject dog in dogs){
	if(dog.gameObject.name == PlayerPrefs.GetString("name")){
		Instantiate(dog,transform)/* as GameObject*/ ;
		}
	}
        /*foreach(GameObject dog in dogs){
	if(dog.gameObject.name == PlayerPrefs.GetString("name")){
	anim = dog.gameObject.GetComponent<Animator>();
	}
	
}*/
anim=GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	txt.text = Convert.ToString (count +"/"+maxCount);
	string zero = Mathf.Floor((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad).ToString().Length == 1 ? "0" : "";
	startTime= Mathf.Floor((time - Time.timeSinceLevelLoad) / 60f).ToString() + ":" + zero  + Mathf.Floor((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad);
	windowTxt.text = Convert.ToString (count +"/"+maxCount +"  "+startTime+"m");
    }

void FixedUpdate()
    {
moveV=joystick.Vertical;
moveH=joystick.Horizontal;

/*moveInput=new Vector3(rb.velocity.x,rb.velocity.y,moveV);
moveVelocity=moveInput.normalized * speed;
rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
*/
//rb.velocity=new Vector3(rb.velocity.x,rb.velocity.y,moveV * speed);
transform.Translate (Vector3.forward * moveV * speed * Time.deltaTime);
if(!yetJump && moveV!=0){
anim.Play("run");
}
/*else if(rb.velocity==Vector3.zero){
anim.Play("idle");
}*/

/*rot=new Vector3(0,moveH * 100,0);
Quaternion deltaRotation = Quaternion.Euler(rot * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation );*/
if(!yetJump){
transform.Rotate(0,moveH,0,Space.World);
}
}
    // Update is called once per frame
    void Update()
    {



	if(Mathf.Ceil(Time.timeSinceLevelLoad) <= time){
		if(Mathf.Ceil(Time.timeSinceLevelLoad) >= time - 10f){
			timeText.color = new Color32(255, 0, 0, 255);
			if(!TimerAudio.isPlaying && !isPause) 
			TimerAudio.Play();
		}
		string zero = Mathf.Floor((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad).ToString().Length == 1 ? "0" : "";
		timeText.text = Mathf.Floor((time - Time.timeSinceLevelLoad) / 60f).ToString() + ":" + zero  + Mathf.Floor((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad);

	}else if(!isPause){
		MainAudio.Stop();
		audio.clip = clips[3];
		audio.Play();
		//Pause(sale, "sale");
		//Pause(lose, "loose");
		pauseBtn.gameObject.SetActive(false);

		audio.loop=!isPause;
		timeText.transform.parent.gameObject.SetActive(isPause);
		txt.transform.parent.gameObject.SetActive(isPause);
		//volumeBtn.gameObject.SetActive(!isPause);
		//windowTxt.gameObject.SetActive(!isPause);
		sale.SetActive(!isPause);
		Time.timeScale=isPause?1:0;
		joystick.gameObject.SetActive(isPause);
		jmpBtn.gameObject.SetActive(isPause);
		isPause=!isPause;
}
/*else if(!isPause){
		MainAudio.Stop();
		audio.clip = clips[3];
		audio.Play();
		Pause(sale, "sale");
		//Pause(lose, "loose");
		pauseBtn.gameObject.SetActive(false);
}*/
//	timeText.text = Mathf.Ceil((Mathf.Ceil(Time.timeSinceLevelLoad / 60f) * 60f) - Time.timeSinceLevelLoad).ToString();

	//rb.velocity= new Vector3 (moveH * speed,rb.velocity.y,moveV * speed);
	if (Input.GetKey("up") ){
	if(!yetJump){
	anim.Play("run");
	}
	 transform.Translate(Vector3.forward * Time.deltaTime * speed);
}
	else if (Input.GetKey("down") ){
	if(!yetJump){
	anim.Play("run");
	}
	transform.Translate(Vector3.forward * Time.deltaTime * -speed);
}
	/*else if(rb.velocity==Vector3.zero){
anim.Play("idle");
}*/
	 if (Input.GetKeyDown(KeyCode.Space) && !yetJump)
         {
	SpaceJump();
	}
	if (Input.GetKey("right") && !yetJump){
Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation );
}
else if (Input.GetKey("left") && !yetJump){
Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity2 * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation );
}
         

	
    }
	void Jumping(){
		audio.clip = clips[0];
		audio.Play();
		anim.Play("jump");
		yetJump = true;
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bone"){
			
			count++;
			audio.clip = clips[1];
			audio.Play();
       			txt.text = Convert.ToString (count +"/"+maxCount);
			if(count==maxCount){
				audio.clip = clips[2];
				audio.Play();
				MainAudio.Stop();
				Pause(win, "win");
				pauseBtn.gameObject.SetActive(false);
				if(lvl>=2){
				PlayerPrefs.SetInt("lvl",1);
				}
				else{
				PlayerPrefs.SetInt("lvl",++lvl);
				print(lvl);
				}
			}
			Destroy(other.gameObject, 0.2f);
		}
	}
	void OnCollisionEnter(Collision other){
		if(/*other.gameObject.tag == "Platform" && */yetJump){
			
			yetJump = false;
			anim.Play("idle");
		}
	}

public void Pause(GameObject show, string desctiption){
audio.loop=!isPause;
timeText.transform.parent.gameObject.SetActive(isPause);
txt.transform.parent.gameObject.SetActive(isPause);
//volumeBtn.gameObject.SetActive(!isPause);
windowTxt.gameObject.SetActive(!isPause);
show.SetActive(!isPause);
Time.timeScale=isPause?1:0;
joystick.gameObject.SetActive(isPause);
jmpBtn.gameObject.SetActive(isPause);
isPause=!isPause;
	/*
	if(description.Contains("loose")){
		
	}
	*/
}

public void PauseClick(GameObject show){
volumeBtn.gameObject.SetActive(!isPause);
windowTxt.gameObject.SetActive(!isPause);
show.SetActive(!isPause);
Time.timeScale=isPause?1:0;
joystick.gameObject.SetActive(isPause);
jmpBtn.gameObject.SetActive(isPause);
isPause=!isPause;
}

public void SpaceJump(){
if ( !yetJump){
	Jumping();
 	rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
	}
}
	
}
