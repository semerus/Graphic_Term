using UnityEngine;
using System.Collections;

public class GridCreater : MonoBehaviour {

	// Use this for initialization
	public float widthX;
	public float heightZ;
	private Vector3 grid;
	void Start () {
		grid.Set (widthX, 1, heightZ);
		transform.localScale = grid;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
