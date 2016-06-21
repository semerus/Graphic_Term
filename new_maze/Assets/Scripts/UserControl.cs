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
	private Quaternion _rightUp = Quaternion.identity;
	private Quaternion _leftUp = Quaternion.identity;
	private Quaternion _rightDown = Quaternion.identity;
	private Quaternion _leftDown = Quaternion.identity;

	ProgressManager progress;

	// Use this for initialization
	void Start () {
		_upRight = Quaternion.Euler (0, 90, 0);
		_downRight = Quaternion.Euler (0, -270, 0);
		_upLeft = Quaternion.Euler (0, -90, 0);
		_downLeft = Quaternion.Euler (0, 270, 0);
		_rightUp = Quaternion.Euler (0, 0, 0);
		_leftUp = Quaternion.Euler (0, -360, 0);
		_rightDown = Quaternion.Euler (0, 180, 0);
		_leftDown = Quaternion.Euler (0, -180, 0);

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
			if (this.transform.rotation == this._downRight) {
				this.progress.instruction.rotationFin = true;
				this.transform.rotation = this._upRight;
			}
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
		if (num == ProgressManager.RIGHTUP_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _rightUp, speed * Time.deltaTime * 2f);
			if(this.transform.rotation == this._rightUp)
				this.progress.instruction.rotationFin = true;
		}
		if (num == ProgressManager.LEFTUP_ROTATE) {
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, _leftUp, speed * Time.deltaTime * 2f);
			if (this.transform.rotation == this._leftUp) {
				this.progress.instruction.rotationFin = true;
				this.transform.rotation = this._rightUp;
			}
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