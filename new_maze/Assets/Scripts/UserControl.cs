using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControl : MonoBehaviour {
	ProgressManager progress;

	public float speed;
	// Use this for initialization
	void Start () {
		speed = speed * Time.deltaTime;
		progress = GameObject.Find("ProgressManager").GetComponent<ProgressManager>();
		Debug.Log (progress.num);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards(this.transform.position, progress.test, speed);
		Debug.Log (progress.test);
	}
}