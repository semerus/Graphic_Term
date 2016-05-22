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
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (progress.test);
		switch (progress.instruction.status) {
		case 0: 
			this.transform.position = Vector3.MoveTowards(this.transform.position, progress.instruction.target, speed);
			if(progress.instruction.rotationFin == false) {
				Debug.Log(progress.instruction.rotation);
				Rotate (this.gameObject, progress.instruction.rotation);
				progress.instruction.rotationFin = true;
			}
			break;
		case 1: 
			break;
		default:
			break;
		}
	}

	//num: 1 right, 2 left
	void Rotate (GameObject player, int num) {
		if (num == ProgressManager.RIGHT_ROTATE)
			player.transform.Rotate (0f, 90f, 0f);
		if (num == ProgressManager.LEFT_ROTATE)
			player.transform.Rotate (0f, -90f, 0f);
		else
			;
	}
}