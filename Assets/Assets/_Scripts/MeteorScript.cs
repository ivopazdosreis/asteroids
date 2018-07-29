using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour {
	
	float speed = -5f;
	
	//random rotation
	float rotation;
	
	void Start () {
		rotation = Random.Range(-40, 40);
	}
	
	void Update () {
		transform.Translate(0f, speed * Time.deltaTime, 0f);
		transform.Rotate(0f, rotation * Time.deltaTime, 0f);
	}
}
