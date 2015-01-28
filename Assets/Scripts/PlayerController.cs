using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	GameObject fpsCamera;

	void Awake () {
		Screen.lockCursor = true;
    	Screen.showCursor = false;
    	fpsCamera = GameObject.Find("Main Camera") as GameObject;
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) 
			Shot();
	}

	void Shot () {
		Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
		ray = fpsCamera.camera.ScreenPointToRay(center);
		if (Physics.Raycast(ray,out hit,100)) {
			Debug.Log(hit.point);
		}
		Debug.DrawLine(ray.origin, ray.direction * 100, Color.yellow);
	}

}
