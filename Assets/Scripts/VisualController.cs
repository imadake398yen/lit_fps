using UnityEngine;
using System.Collections;

public class VisualController : MonoBehaviour {

	public Vector3 colorselect;

	void Start () {
		MeshFilter mf = GetComponent<MeshFilter>();
	    mf.mesh.SetIndices(mf.mesh.GetIndices(0),MeshTopology.LineStrip,0);
	}

	void Update () {
		colorselect.x=Random.Range(1f,6f);
		colorselect.y=Random.Range(1f,6f);
		colorselect.z=Random.Range(1f,6f);
		MeshRenderer mr = GetComponent<MeshRenderer>();
  		Color selected = new Color(colorselect.x,colorselect.y,colorselect.z);
  		mr.material.color = selected;
	}
}
