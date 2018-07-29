using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	float speed = 10f;
	
	//Game Control Script
	GameControlScript control;
	
	void Start () {
		//Since this is instantiated, we must find
		//the game control at run time
		control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	void Update () {
		transform.Translate(0f, speed * Time.deltaTime, 0f);
	}
	
	//neither bullet or meteor is a trigger, so we need
	//to use a different collision method here
	void OnCollisionEnter(Collision other)
	{
		Destroy(other.gameObject);
		control.AddScore();
		Destroy(this.gameObject);
	}
}
