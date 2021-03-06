﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// 使用する変数
	public GameObject playerCamera;
	public GameObject sparks;
	public GameObject hitSound;
	public AudioSource audio;
	public Text bulletLabel;
	Ray ray;
	RaycastHit hit;
	float shotInterval = 0.1f;
	int magagine = 30;
	int bullet = 300;



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

		if (Input.GetKeyDown("r")) {
			print("Reload!");
			BulletReload();
		}

	}


	void Shot () {

		if (magagine > 0) {

			audio.PlayOneShot(audio.clip);
			Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
			ray = playerCamera.camera.ScreenPointToRay(center);
			if (Physics.Raycast(ray,out hit,100)) {
				// Debug.Log(hit.point);
				GameObject se = Instantiate (hitSound, hit.point, Quaternion.identity) as GameObject;
				Destroy(se.gameObject, 0.2f);
				if (hit.transform.gameObject.tag == "Enemy") hit.transform.gameObject.SendMessage("ReceiveDamage",1);
			}
			Debug.DrawLine(ray.origin, ray.direction * 100, Color.yellow);

			magagine--;
			bulletLabel.text = magagine + " / " + bullet;

		}

	}


	void BulletReload () {
		if (bullet >= 30) {
			bullet -= (30 - magagine);
			magagine = 30;
			bulletLabel.text = magagine + " / " + bullet;
		} else if (0 < bullet && bullet < 30) {
			magagine += bullet;
			bullet = 0;
			bulletLabel.text = magagine + " / " + bullet;
		} else {
			return;
		}
	}


}
