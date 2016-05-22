using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {
	
	private GameObject _buttonLeft;
	private GameObject _buttonRight;

	public int num = 1;
	Vector3 test;
	private GameObject sub;
	private GameObject player;
	// Use this for initialization
	void Start () {

		//test.Set(GameObject.Find("marker66").transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	sub = GameObject.Find ("marker76");
	test = sub.transform.position;
	if(test == player.transform.position);

}

/*
Scenario
 1, 2, 3
 */