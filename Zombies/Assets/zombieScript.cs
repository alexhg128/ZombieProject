using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class zombieScript : MonoBehaviour {
	//declarar el transform of our goal (donde el navmesh se moverá para enfrente) el navmesh agent (en este caso nuestro zombie)
	private Transform goal;
	private NavMeshAgent agent;
	public float Timespawn = 3f; 
	public bool t = false;
	public float distanceMax;
	public int damage;

	//  initialization
	void Start () {

		//create references
		goal = Camera.main.transform;
		agent = GetComponent<NavMeshAgent>();
		//la destinación de cada zombie es = a la del personaje (la cámara)
		agent.destination = goal.position;
		//empezar a caminar animation
		GetComponent<Animation>().Play ("walk");
		/*GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

		//poner las coordenadas al nuevo V3
		float randomX = UnityEngine.Random.Range (-48f,0f);
		float constantY = .01f;
		float randomZ = UnityEngine.Random.Range (-32f,39f);
		//poner la posición del zombie a estas condenadas
		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

		//si el zombie esta de 3 o menos pies no podremos dispararle al zombie
		//reposicional al zombie asta que se le pueda disparar        while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 5) {

		randomX = UnityEngine.Random.Range (-48f,0f);
		randomZ = UnityEngine.Random.Range (-32f,39f);

		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);*/

	}

	void Update () {
		agent.destination = goal.position;

		if (t) {
			agent.destination = gameObject.transform.position;
		}
		HPCounter script = GameObject.Find ("Life").GetComponent<HPCounter> ();
		Vector3 uZ = gameObject.transform.position;
		Vector3 uP = GameObject.Find ("FirstPersonCharacter").transform.position;
		if (distance(uP, uZ) < distanceMax) {
			script.Damage (damage);
		}
	}

	private float distance(Vector3 v1, Vector3 v2)
	{
		return Mathf.Sqrt (Mathf.Pow (v1.x - v2.x, 2) + Mathf.Pow (v1.z - v2.z, 2));
	}

	//es vital que amenos uno de los 2 tenga rigidez body y el zombie tenga triger activado
	public void OnTriggerEnter (/*Collider col*/)
	{
		//evita que aya múltiples colisiones
		t = true;
		GetComponent<CapsuleCollider>().enabled = false;
		//Destruir la bala
		//Destroy(col.gameObject);
		// Esto evita que le zombie se siga moviendo
		agent.destination = gameObject.transform.position;
		//parar la animación de movimiento por y poner la de chida
		GetComponent<Animation>().Stop ();
		GetComponent<Animation>().Play ("back_fall");
		//destruir en 2 segundos.
		Destroy (gameObject, 1);
		//saca a otro zombie
		/*GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

		//poner las coordenadas al nuevo V3
		float randomX = UnityEngine.Random.Range (-48f,0f);
		float constantY = .01f;
		float randomZ = UnityEngine.Random.Range (-32f,39f);
		//poner la posición del zombie a estas condenadas
		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

		//si el zombie esta de 3 o menos pies no podremos dispararle al zombie
		//reposicional al zombie asta que se le pueda disparar        while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 5) {

			randomX = UnityEngine.Random.Range (-48f,0f);
			randomZ = UnityEngine.Random.Range (-32f,39f);

		zombie.transform.position = new Vector3 (randomX, constantY, randomZ);*/
	}

}

