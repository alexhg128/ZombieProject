using UnityEngine;
using System.Collections;
using UnityEditor;

public class EnemyManager : MonoBehaviour
{
	//public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject zombiee;                // The enemy prefab to be spawned.
	private float nextZombie;


	 
	void Start()
	{
		nextZombie = Time.unscaledTime + 2;

	}





	void Update ()
	{
		//Debug.Log ("" + Time.timeSinceLevelLoad);

		if (Time.unscaledTime > nextZombie) {
			Spawn ();
			nextZombie = Time.unscaledTime + 2;
		}


	}

	void Spawn()
	{
		Object prefab = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/zombiee.prefab", typeof(GameObject));
		GameObject zombie = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
		Debug.Log ("Im in");
		//poner las coordenadas al nuevo V3
		float randomX = UnityEngine.Random.Range (-48f, 0f);
		float constantY = .01f;
		float randomZ = UnityEngine.Random.Range (-32f, 39f);
		//poner la posición del zombie a estas condenadas
		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

		//si el zombie esta de 3 o menos pies no podremos dispararle al zombie
		//reposicional al zombie asta que se le pueda disparar        while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 5) {

		randomX = UnityEngine.Random.Range (-48f, 0f);
		randomZ = UnityEngine.Random.Range (-32f, 39f);

		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
	}
}