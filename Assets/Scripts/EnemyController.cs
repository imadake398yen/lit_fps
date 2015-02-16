using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int hitPoint = 10;
	public GameObject effect;
	public Transform[] points;
	int currentPoint = 0;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		
		Vector3 pos = points[currentPoint].position;

		// 目的地に達したら次の目的地をセットする
		if (Vector3.Distance(transform.position, pos) < 0.5f) {
			if (currentPoint < points.Length - 1) {
				currentPoint++;
			} else {
				currentPoint = 0;
			}
		}
		
		// セットした目的地に障害物を避けながら向かうコード
		agent.SetDestination(points[currentPoint].position);
	
	}
			
	void ReceiveDamage (int damage) {
		print("hit");
		hitPoint -= damage;
		if (hitPoint <= 0) {
			Instantiate (effect, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}	

}
