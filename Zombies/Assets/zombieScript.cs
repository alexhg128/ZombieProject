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
	public bool isDead;

	//  initialization
	void Start () {

		//create references
		goal = Camera.main.transform;
		agent = GetComponent<NavMeshAgent>();
		//la destinación de cada zombie es = a la del personaje (la cámara)
		agent.destination = goal.position;
		//empezar a caminar animation
		GetComponent<Animation>().Play ("walk");


	}

	void Update () {
		agent.destination = goal.position;

		if (t) {
			agent.destination = gameObject.transform.position;
		}
		HPCounter script = GameObject.Find ("Life").GetComponent<HPCounter> ();
		Vector3 uZ = gameObject.transform.position;
		Vector3 uP = GameObject.Find ("FirstPersonCharacter").transform.position;
		if ((distance(uP, uZ) < distanceMax)&&isDead==false) {
			script.Damage (damage);
			//Return to true just in case that the zombie is not destroyed for some weird reason
			isDead = true;
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
		//If the zombie has died let the system know it has died so it can't make damage
		isDead = true;
		// Esto evita que le zombie se siga moviendo
		agent.destination = gameObject.transform.position;
		//parar la animación de movimiento por y poner la de chida
		GetComponent<Animation>().Stop ();
		GetComponent<Animation>().Play ("back_fall");
		//destruir en 1 segundo.
		Destroy (gameObject, 1);

	}

}

