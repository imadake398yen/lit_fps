using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// 使用する変数
	public GameObject playerCamera;
	public GameObject sparks;
	public GameObject hitSound;
	public AudioSource audio;
	Ray ray;
	RaycastHit hit;
	float shotInterval = 0.1f;


	void Awake () {
		// マウスカーソルをなくす
		Screen.lockCursor = true;
  		Screen.showCursor = false;
	}

	
	void Update () {

		// 左クリックした瞬間
		if (Input.GetMouseButtonDown(0)) {
			sparks.SetActive(true);
		}
		// 左クリックを話した瞬間
		if (Input.GetMouseButtonUp(0)) {
			sparks.SetActive(false);
		}
		// 左クリック押し続けてる間
		if (Input.GetMouseButton(0)) { 
			shotInterval -= Time.deltaTime;
			if (shotInterval < 0) {
				shotInterval = 0.1f;
				Shot();
			}
		}

	}


	void Shot () {
		audio.PlayOneShot(audio.clip);
		Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
		ray = playerCamera.camera.ScreenPointToRay(center);
		if (Physics.Raycast(ray,out hit,100)) {
			// Debug.Log(hit.point);
			GameObject se = Instantiate (hitSound, hit.point, Quaternion.identity) as GameObject;
			Destroy(se.gameObject, 0.6f);
		}
		Debug.DrawLine(ray.origin, ray.direction * 100, Color.yellow);
	}


}
