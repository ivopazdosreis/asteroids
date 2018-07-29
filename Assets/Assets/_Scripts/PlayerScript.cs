using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	//player speed
	public float speed = 10f;
	
	//Control Script
	public GameControlScript control;
		
	//bullet prefab
	public GameObject bullet;	
	
	//player can fire a bullet every half second
	public float bulletThreshold = .5f;
	float ellapsedTime = 0;
	
	void Start () {
	
	}
	
	void Update () {
		//keeping track of time for bullet firing
		ellapsedTime += Time.deltaTime;
		
		//move the player sideways
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
		
		//spacebar fires. The current setup calls this "Jump"
		//this was left to avoid confusion
		if(Input.GetButtonDown("Jump"))
		{
			//see if enough time has passed to fire a new bullet
			if(ellapsedTime > bulletThreshold)
			{
				//fire bullet at current position
				//be sure the bullet is created in front of the player
				//so they don't collide
				Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.2f, -5f), Quaternion.identity);
				
				//reset bullet firing timer
				ellapsedTime = 0f;
			}
		}
		
	}
	
	//if a meteor hits the player
	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		control.PlayerDied();
		Destroy(this.gameObject);
	}
}
