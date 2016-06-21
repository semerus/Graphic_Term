using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour {
	//const for rotation declaration
	public const int UPLEFT_ROTATE = 5;
	public const int DOWNLEFT_ROTATE = 2;
	public const int UPRIGHT_ROTATE = 1;
	public const int DOWNRIGHT_ROTATE = 6;
	public const int RIGHTDOWN_ROTATE = 3;
	public const int LEFTDOWN_ROTATE = 7;
	public const int RIGHTUP_ROTATE = 4;
	public const int LEFTUP_ROTATE = 8;
	public const int NO_ROTATION = 0;

	public const int MOVING = 0;
	public const int CHOOSING = 1;
	public const int BATTLING = 2;
	public const int END = 3;

	private int _stateNum = 0; //scenario number
	private int stageJumper = 0; //stageJumper to keep track of stages in one command
	public InsTructions instruction; //instructions given to UserControl(player)

	GameObject markerDes1; //1st destination, current destination
	GameObject markerDes2; //second destination
	GameObject markerDes3; //third destination
	GameObject markerFinal; //final destination used for buttons
	GameObject player;
	
	GameObject buttonLeft;
	GameObject buttonRight;
	GameObject buttonForward;
	GameObject buttonBackward;
	GameObject winText;

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
		winText = GameObject.FindGameObjectWithTag ("WinText");

		instruction.movingFin = true;
		instruction.rotationFin = true;
		instruction.playerStatus = 0;

		buttonLeft.GetComponentInChildren<Text>().text = "Go Left";
		buttonRight.GetComponentInChildren<Text>().text = "Go Right";
		buttonForward.GetComponentInChildren<Text> ().text = "Go Forward";
		buttonBackward.GetComponentInChildren<Text> ().text = "Go Back";
		winText.GetComponent<Text> ().text = "Well Done";

		buttonLeft.SetActive (false);
		buttonRight.SetActive (false);
		buttonForward.SetActive (false);
		buttonBackward.SetActive (false);
		winText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (_stateNum+"true"+instruction.rotationFin+"status"+instruction.playerStatus);
		switch (_stateNum) { //scenarios of the game, refer to the Excel file(maze.xlsx)
		case 0: // start #0
			MoveThisWay ("marker76", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = CHOOSING;
			if(instruction.playerStatus == CHOOSING) {
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
			MoveThisWay ("marker66", UPRIGHT_ROTATE, "marker68", RIGHTDOWN_ROTATE, "marker78", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = BATTLING;
			if(instruction.playerStatus == CHOOSING) {
				buttonBackward.SetActive (true);
			}
			if(backwardInput == true) {
				_stateNum = 9;
				stageJumper = 0;
				backwardInput = false;
				ButtonOut();
			}
			break;
		case 2: // going left at point #1
			MoveThisWay("marker66", UPLEFT_ROTATE, "marker62", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = CHOOSING;
			if(instruction.playerStatus == CHOOSING) {
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
		case 3: // going right at point #2
			MoveThisWay("marker61", RIGHTUP_ROTATE, "marker41", UPRIGHT_ROTATE, "marker43", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = BATTLING;
			if(instruction.playerStatus == CHOOSING) {
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
		case 4: // going left at point #2
			MoveThisWay ("marker61", LEFTDOWN_ROTATE, "marker81", DOWNRIGHT_ROTATE, "marker82", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = BATTLING;
			if (instruction.playerStatus == CHOOSING)
				buttonBackward.SetActive (true);
			if (backwardInput == true) {
				_stateNum = 10;
				stageJumper = 0;
				backwardInput = false;
				ButtonOut ();
			}
			break;
		case 5: // going left at point #3
			MoveThisWay("marker44", RIGHTUP_ROTATE, "marker24", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = CHOOSING;
			if(instruction.playerStatus == CHOOSING) {
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
		case 6: // going forward at point #3
			MoveThisWay ("marker48", RIGHTUP_ROTATE, "marker38", NO_ROTATION);
			if (instruction.playerStatus == END)
				instruction.playerStatus = BATTLING;
			if (instruction.playerStatus == CHOOSING)
				buttonBackward.SetActive (true);
			if (backwardInput == true) {
				_stateNum = 11;
				stageJumper = 0;
				backwardInput = false;
				ButtonOut ();
			}
			break;
		case 7: // going left at point #4
			MoveThisWay ("marker14", UPLEFT_ROTATE, "marker11", LEFTDOWN_ROTATE);
			if (instruction.playerStatus == END)
				instruction.playerStatus = BATTLING;
			if (instruction.playerStatus == CHOOSING) {
				buttonBackward.SetActive (true);
			}
			if (backwardInput == true) {
				_stateNum = 13;
				stageJumper = 0;
				backwardInput = false;
				ButtonOut ();
			}
			break;
		case 8: // going right at point #4
			MoveThisWay("marker14", UPRIGHT_ROTATE, "marker16", RIGHTUP_ROTATE, "marker06", NO_ROTATION);
			if (instruction.playerStatus == END)
				winText.SetActive (true);
			break;
		case 9: // turning back at marker78
			MoveThisWay ("marker78", RIGHTUP_ROTATE, "marker68", UPLEFT_ROTATE);
			if (instruction.playerStatus == END)
				instruction.playerStatus = CHOOSING;
			if (instruction.playerStatus == CHOOSING) {
				_stateNum = 2;
				stageJumper = 0;
			}
			break;
		case 10: // turning back at marker82
			MoveThisWay ("marker82", UPLEFT_ROTATE, "marker81", RIGHTUP_ROTATE);
			if (instruction.playerStatus == END) {
				_stateNum = 3;
				stageJumper = 0;
			}
			break;
		case 11: // turning back at marker38
			MoveThisWay ("marker38", RIGHTDOWN_ROTATE, "marker48", DOWNLEFT_ROTATE, "marker45", NO_ROTATION);
			if (instruction.playerStatus == END) {
				_stateNum = 12;
				stageJumper = 0;
			}
			break;
		case 12: // continued from case 11
			MoveThisWay ("marker44", LEFTUP_ROTATE);
			if (instruction.playerStatus == END) {
				_stateNum = 5;
				stageJumper = 0;
			}
			break;
		case 13:
			MoveThisWay ("marker11", DOWNRIGHT_ROTATE, "marker14", NO_ROTATION);
			if (instruction.playerStatus == END) {
				_stateNum = 8;
				stageJumper = 0;
			}
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
		public bool rotationStart; // counter for starting rotation, false not yet turned rotationFin false
		public bool rotationFin; //false not done(activate), true done
		public int rotation; // 1 is right, 2 is left, 0 is none

	}

	public void ButtonOut() { // method for shutting out all the buttons
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
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 1;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 1: //choosing time
			this.instruction.playerStatus = END;
			this.stageJumper = 2;
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
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 1;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 1:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes2.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes2.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot2; //do second rotation
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 2;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 2: //choosing time
			this.instruction.playerStatus = END;
			this.stageJumper = 3;
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
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 1;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 1:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes2.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes2.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot2; //do second rotation
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 2;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 2:
			this.instruction.playerStatus = 0;
			this.instruction.moving = markerDes3.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerDes3.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot3; //do third rotation
				if(this.instruction.rotationStart == false) {
					this.instruction.rotationFin = false;
					this.instruction.rotationStart = true;
				}
				if(this.instruction.rotationFin == true) {
					this.stageJumper = 3;
					this.instruction.rotationStart = false;
				}
			}
			break;
		case 3:
			this.instruction.playerStatus = END;
			this.stageJumper = 4;
			break;
		default:
			break;
		}
	}
}