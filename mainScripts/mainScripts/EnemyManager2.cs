using UnityEngine;
using System.Collections;

public class EnemyManager2 : MonoBehaviour
{               
	public GameObject zombiee;
	//variable to count every two seconds
	private float nextZombie;

	void Start(){
		//initialize time with 2 seconds
		nextZombie = Time.unscaledTime +2;
	}
		
	void Update (){
		//If current time is greater than the previous one, which increases every two seconds
		if (Time.unscaledTime > nextZombie) {
			//make the new zombie every 2 seconds
			spawn ();
			nextZombie = Time.unscaledTime + 2;
		}
	}

	void spawn()
	{
		//Generate a new Zombie as GameObject
		GameObject zombie = Instantiate (zombiee, Vector3.zero, Quaternion.identity) as GameObject;
		//Generate random position for the newZombie, let the position in Y constant
		float randomX = UnityEngine.Random.Range (-48f, 0f);
		float constantY = .01f;
		float randomZ = UnityEngine.Random.Range (-32f, 39f);
		//Set the zombie position to the random position generated
		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
		//activate the new Zombie
		zombie.SetActive(true);
	}
}