using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControl : MonoBehaviour {
	//declaring speed of the game
	public float speed;

	//declaring Quaternion for rotation
	private Quaternion _right = Quaternion.identity;
	private Quaternion _left = Quaternion.identity;

	ProgressManager progress;

	// Use this for initialization
	void Start () {
		_left.SetEulerAngles(0f, -Mathf.PI/2, 0f);
		_right.SetEulerAngles(0f, Mathf.PI/2, 0f);

		progress = GameObject.Find("ProgressManager").GetComponent<ProgressManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.transform.rotation+"bool"+progress.instruction.rotationFin+"progress"+progress.instruction.moving);
		switch (progress.instruction.playerStatus) {
		case 0: //moving
			if(progress.instruction.rotationFin == false) {
				//Rotate (this.gameObject, progress.instruction.rotation);
				//this.transform.rotation = Quaternion.AngleAxis(
				//this.transform.Rotate(0f, 90f, 0f);
			}
			else {
				this.transform.position = Vector3.MoveTowards(this.transform.position, progress.instruction.moving, speed * Time.deltaTime);
			}
			break;
		case 1: //choosing
			break;
		case 2: //battling
			break;
		default:
			break;
		}
	}

	//num: 1 right, 2 left
	void Rotate (GameObject player, int num) {
		if (num == ProgressManager.RIGHT_ROTATE) {
			this.transform.Rotate (0f, 90f * Time.deltaTime, 0f);
			/*this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _right, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._right)*/
				//this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.LEFT_ROTATE) {
			this.transform.Rotate (0f, -90f * Time.deltaTime, 0f);
			/*this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _left, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._left)*/
				//this.progress.instruction.rotationFin = true;
		} else
			this.progress.instruction.rotationFin = true;
	}
}