using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int hitPoint = 10;
	public GameObject effect;
			
	void ReceiveDamage (int damage) {
		print("hit");
		hitPoint -= damage;
		if (hitPoint <= 0) {
			Instantiate (effect, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}	

}
