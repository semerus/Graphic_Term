using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControl : MonoBehaviour {
	//declaring speed of the game
	public float speed;

	//declaring Quaternion for rotation
	private Quaternion _upRight = Quaternion.identity;
	private Quaternion _downRight = Quaternion.identity;
	private Quaternion _upLeft = Quaternion.identity;
	private Quaternion _downLeft = Quaternion.identity;
	private Quaternion _up = Quaternion.identity;
	private Quaternion _rightDown = Quaternion.identity;
	private Quaternion _leftDown = Quaternion.identity;

	ProgressManager progress;

	// Use this for initialization
	void Start () {
		_upRight.SetEulerAngles(0f, Mathf.PI/2, 0f);
		_downRight.SetEulerAngles (0f, -Mathf.PI*1.5f, 0f);
		_upLeft.SetEulerAngles (0f, -Mathf.PI/2, 0f);
		_downLeft.SetEulerAngles(0f, Mathf.PI*1.5f, 0f);
		_up.SetEulerAngles (0f, 0f, 0f);
		_rightDown.SetEulerAngles (0f, Mathf.PI, 0f);
		_leftDown.SetEulerAngles (0f, -Mathf.PI, 0f);

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

	//rotation methods
	void Rotate (GameObject player, int num) {
		if (num == ProgressManager.UPRIGHT_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _upRight, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._upRight)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.DOWNRIGHT_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _downRight, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._downRight)
				this.progress.instruction.rotationFin = true;		
		}
		if (num == ProgressManager.UPLEFT_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _upLeft, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._upLeft)
				this.progress.instruction.rotationFin = true;		
		}
		if (num == ProgressManager.DOWNLEFT_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _downLeft, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._downLeft)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.UP_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _up, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._up)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.RIGHTDOWN_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _rightDown, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._rightDown)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.LEFTDOWN_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _leftDown, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._leftDown)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.NO_ROTATION)
			this.progress.instruction.rotationFin = true;
	}
}