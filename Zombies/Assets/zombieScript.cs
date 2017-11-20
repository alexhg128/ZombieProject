using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Animations;

public class zombieScript : MonoBehaviour {

	private Transform goal;
	private NavMeshAgent agent;
	public float timeSpawn = 5f;
	public float distanceMax;
	public int damage;
	public bool isDead = false;

	//  initialization
	void Start () {
		//Make the goal of theh zombie the position of the player
		goal = Camera.main.transform;
		//Get the NavMeshAgent
		agent = GetComponent<NavMeshAgent>();
		//Tell the agent where to go, which is the position of the player
		agent.destination = goal.position;
		//Run the walking animation of the zombie
		GetComponent<Animation>().Play ("walk");
	}

	void Update () {
		//Tell the agent where to go, which is the position of the player
		agent.destination = goal.position;
		//If the zombie is dead fix its position
		if (isDead) {
			agent.destination = gameObject.transform.position;
		}
		//Get the life counter script to use the function damage()
		HPCounter script = GameObject.Find ("Life").GetComponent<HPCounter> ();
		//Get the zombie and player position
		Vector3 uZ = gameObject.transform.position;
		Vector3 uP = GameObject.Find ("FirstPersonCharacter").transform.position;
		//If the zombie is close enough to the player and is not dead make damage
		//and run the attack animation. If it is not dead play walk animation
		if ((distance (uP, uZ) < distanceMax) && isDead == false) {
			GetComponent<Animation>().Play ("attack");
			script.Damage (damage);
		}
		else if ( isDead == false ) {
			GetComponent<Animation>().Play ("walk");
		}
	}
	//Calculate distance between the player and the zombie
	private float distance(Vector3 v1, Vector3 v2){
		return Mathf.Sqrt (Mathf.Pow (v1.x - v2.x, 2) + Mathf.Pow (v1.z - v2.z, 2));
	}
	//This function is called when the zombie and the bullet of the gun collide
	//It is important that at least one has a rigid body, and that the zombie has trigger activated 
	public void OnTriggerEnter (){
		//This avoids to have multiple collisions
		GetComponent<CapsuleCollider>().enabled = false;
		//If the zombie has died let the system know it has died so it can't make damage
		isDead = true;
		// This makes that the zombie stops walking
		agent.destination = gameObject.transform.position;
		//Stop the animation of the zombie, and run the one in which it falls back
		GetComponent<Animation>().Stop ();
		GetComponent<Animation>().Play ("back_fall");
		//Destroy the Zombie in the duration definded by the timeSpawn.
		Destroy (gameObject, timeSpawn);
	}

}
