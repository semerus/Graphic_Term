using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControl : MonoBehaviour {
	//declaring speed of the game
	public float speed;

	//declaring Quaternion for rotation
	private Quaternion _right = Quaternion.identity;
	private Quaternion _left = Quaternion.identity;
	private Quaternion _up = Quaternion.identity;
	private Quaternion _down = Quaternion.identity;

	ProgressManager progress;

	// Use this for initialization
	void Start () {
		_left.SetEulerAngles(0f, Mathf.PI*1.5f, 0f);
		_right.SetEulerAngles(0f, Mathf.PI/2, 0f);
		_up.SetEulerAngles (0f, 0f, 0f);
		_down.SetEulerAngles (0f, Mathf.PI, 0f);

		progress = GameObject.Find("ProgressManager").GetComponent<ProgressManager>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (progress.instruction.playerStatus) {
		case 0: //moving
			if(progress.instruction.rotationFin == false)
				Rotate (this.gameObject, progress.instruction.rotation);
			else 
				this.transform.position = Vector3.MoveTowards(this.transform.position, progress.instruction.moving, speed * Time.deltaTime);
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
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _right, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._right)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.LEFT_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _left, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._left)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.UP_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _up, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._up)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.DOWN_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _down, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._down)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.NO_ROTATION)
			this.progress.instruction.rotationFin = true;
	}
}