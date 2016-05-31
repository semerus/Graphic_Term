using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour {
	//const for rotation declaration
	public const int LEFT_ROTATE = 2;
	public const int RIGHT_ROTATE = 1;
	public const int NO_ROTATION = 0;

	private int _stateNum = 0; //scenario number
	private int stageJumper = 0; //stageJumper to keep track of stages in one command
	public InsTructions instruction; //instructions given to UserControl(player)

	GameObject markerDes1; //1st destination, current destination
	GameObject markerDes2; //second destination
	GameObject markerDes3; //third destination
	GameObject markerFinal;
	GameObject player;
	
	GameObject buttonLeft;
	GameObject buttonRight;
	GameObject buttonForward;
	GameObject buttonBackward;

	bool leftInput = false;
	bool rightInput = false;
	bool forwardInput = false;
	bool backwardInput = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		buttonLeft = GameObject.FindGameObjectWithTag("ButtonLeft");
		buttonRight = GameObject.FindGameObjectWithTag("ButtonRight");
		buttonForward = GameObject.FindGameObjectWithTag("ButtonForward");
		buttonBackward = GameObject.FindGameObjectWithTag("ButtonBackward");

		instruction.movingFin = true;
		instruction.rotationFin = true;
		instruction.playerStatus = 0;

		buttonLeft.GetComponentInChildren<Text>().text = "Go Left";
		buttonRight.GetComponentInChildren<Text>().text = "Go Right";
		buttonForward.GetComponentInChildren<Text> ().text = "Go Forward";
		buttonBackward.GetComponentInChildren<Text> ().text = "Go Back";

		buttonLeft.SetActive (false);
		buttonRight.SetActive (false);
		buttonForward.SetActive (false);
		buttonBackward.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		switch (_stateNum) { //scenarios of the game, refer to the Excel file(maze.xlsx)
		case 0: // start #0
			markerFinal = GameObject.Find ("marker76"); // final point of the case
			MoveThisWay("marker76", 0);
			if((Vector3.Distance (this.player.transform.position, this.markerFinal.transform.position) < 0.0001f)) {
				//instruction.playerStatus = 1; // change playerStatus to choosing(1)
				buttonLeft.SetActive (true);
				buttonRight.SetActive (true);
			}
			if(rightInput == true) {
				_stateNum = 1;
				stageJumper = 0;
				rightInput = false;
				ButtonOut();
			}
			if(leftInput == true) {
				_stateNum = 2;
				stageJumper = 0;
				leftInput = false;
				ButtonOut();
			}
			break;
		case 1: // going right at point #1
			markerFinal = GameObject.Find ("marker68");
			MoveThisWay("marker66", RIGHT_ROTATE, "marker68", RIGHT_ROTATE);
			break;
		case 2: // going left at point #1
			markerFinal = GameObject.Find ("marker62");
			MoveThisWay("marker66", LEFT_ROTATE, "marker62", NO_ROTATION);
			if((Vector3.Distance (this.player.transform.position, this.markerFinal.transform.position) < 0.0001f)) {
				buttonLeft.SetActive (true);
				buttonRight.SetActive (true);
			}
			if(leftInput == true) {
				_stateNum = 4;
				stageJumper = 0;
				leftInput = false;
				ButtonOut();
			}
			if(rightInput == true) {
				_stateNum = 3;
				stageJumper = 0;
				rightInput = false;
				ButtonOut();
			}
			break;
		case 3: 
			markerFinal = GameObject.Find ("marker43");
			MoveThisWay("marker61", RIGHT_ROTATE, "marker41", RIGHT_ROTATE, "marker43", NO_ROTATION);
			if((Vector3.Distance (this.player.transform.position, this.markerFinal.transform.position) < 0.0001f)) {
				buttonLeft.SetActive (true);
				buttonForward.SetActive (true);
			}
			if(leftInput == true) {
				_stateNum = 5;
				stageJumper = 0;
				leftInput = false;
				ButtonOut();
			}
			if(forwardInput == true) {
				_stateNum = 6;
				stageJumper = 0;
				forwardInput = false;
				ButtonOut();
			}
			break;
		case 4:
			break;
		case 5:
			markerFinal = GameObject.Find ("marker24");
			MoveThisWay("marker44", LEFT_ROTATE, "marker24", NO_ROTATION);
			if((Vector3.Distance (this.player.transform.position, this.markerFinal.transform.position) < 0.0001f)) {
				buttonLeft.SetActive (true);
				buttonRight.SetActive (true);
			}
			if(leftInput == true) {
				_stateNum = 7;
				stageJumper = 0;
				leftInput = false;
				ButtonOut();
			}
			if(rightInput == true) {
				_stateNum = 8;
				stageJumper = 0;
				rightInput = false;
				ButtonOut();
			}
			break;
		case 6:
			break;
		default: 
			break;
		}
	}

	//structure of instruction
	public struct InsTructions {
		public int playerStatus; // 0 is moving, 1 is choosing, 2 is none
		public bool movingFin; // false not done(activate), true done
		public Vector3 moving; // moving(to) position
		public bool rotationFin; //false not done(activate), true done
		public int rotation; // 1 is right, 2 is left, 0 is none

	}

	public void ButtonOut() {
		this.buttonLeft.SetActive (false);
		this.buttonRight.SetActive (false);
		this.buttonForward.SetActive (false);
		this.buttonBackward.SetActive (false);
	}

	//button clicks
	public void LeftButtonClick()
	{
		this.leftInput = true;
	}

	public void RightButtonClick()
	{
		this.rightInput = true;
	}

	public void ForwardButtonClick()
	{
		this.forwardInput = true;
	}

	public void BackwardButtonClick()
	{
		this.backwardInput = true;
	}

	//moving method x1
	public void MoveThisWay(string des1, int rot1) {
		this.markerDes1 = GameObject.Find (des1); //1st destination
		switch(this.stageJumper) {
		case 0: 
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes1.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes1.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot1; //do first rotation
				this.instruction.rotationFin = false;
				this.stageJumper = 1;
			}
			break;
		default:
			break;
		}
	}
	//moving method x2
	public void MoveThisWay(string des1, int rot1, string des2, int rot2) {
		this.markerDes1 = GameObject.Find (des1); //1st destination
		this.markerDes2 = GameObject.Find (des2); //2nd destination
		switch(this.stageJumper) {
		case 0:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes1.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes1.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot1; //do first rotation
				if(this.instruction.rotationFin == true)
					this.stageJumper = 1;
				this.instruction.rotationFin = false;
			}
			break;
		case 1:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes2.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes2.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot2; //do second rotation
				if(this.instruction.rotationFin == true)
					this.stageJumper = 2;
				this.instruction.rotationFin = false;
			}
			break;
		default:
			break;
		}
	}
	//moving method x3
	public void MoveThisWay(string des1, int rot1, string des2, int rot2, string des3, int rot3) {
		this.markerDes1 = GameObject.Find (des1); //1st destination
		this.markerDes2 = GameObject.Find (des2); //2nd destination
		this.markerDes3 = GameObject.Find (des3); //3rd destination
		switch(this.stageJumper) {
		case 0:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes1.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes1.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot1; //do first rotation
				if(this.instruction.rotationFin == true)
					this.stageJumper = 1;
				this.instruction.rotationFin = false;
			}
			break;
		case 1:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes1.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes2.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot2; //do second rotation
				if(this.instruction.rotationFin == true)
					this.stageJumper = 2;
				this.instruction.rotationFin = false;
			}
			break;
		case 2:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes1.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes3.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot3; //do third rotation
				if(this.instruction.rotationFin == true)
					this.stageJumper = 3;
				this.instruction.rotationFin = false;
			}
			break;
		default:
			break;
		}
	}
}