using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject fpsCamera;
	public GameObject sparks;
	public GameObject hitSound;
	public AudioSource audio;
	Ray ray;
	RaycastHit hit;
	float shotInterval = 0.1f;


	void Awake () {
		Screen.lockCursor = true;
  		Screen.showCursor = false;
	}

	
	void Update () {

		Debug.Log(Input.mousePosition);

		if (Input.GetMouseButtonDown(0)) {
			sparks.SetActive(true);
		}

		if (Input.GetMouseButtonUp(0)) {
			sparks.SetActive(false);
		}

		if (Input.GetMouseButton(0)){ 
			shotInterval -= Time.deltaTime;
			if (shotInterval < 0) {
				audio.PlayOneShot(audio.clip);
				shotInterval = 0.1f;
				Shot();
			}
		}

	}


	void Shot () {
		Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
		ray = fpsCamera.camera.ScreenPointToRay(center);
		if (Physics.Raycast(ray,out hit,100)) {
			Debug.Log(hit.point);
			GameObject se = Instantiate (hitSound, hit.point, Quaternion.identity) as GameObject;
			Destroy(se.gameObject, 0.6f);
		}
		Debug.DrawLine(ray.origin, ray.direction * 100, Color.yellow);
	}


}
