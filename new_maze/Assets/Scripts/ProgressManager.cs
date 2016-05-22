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

	GameObject markerFinder; //1st destination, current destination
	GameObject markerFinder2; //second destination
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
		instruction.rotationFin = true;
		instruction.status = 0;

		buttonLeft.GetComponentInChildren<Text>().text = "Go Left";
		buttonRight.GetComponentInChildren<Text>().text = "Go Right";

		buttonLeft.SetActive (false);
		buttonRight.SetActive (false);
		buttonForward.SetActive (false);
		buttonBackward.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		switch (_stateNum) { //scenarios of the game, refer to the Excel file(maze.xlsx)
		case 0: // start #0
			markerFinder = GameObject.Find ("marker76");
			instruction.target = markerFinder.transform.position;
			if((Vector3.Distance (this.player.transform.position, this.markerFinder.transform.position) < 0.0001f)) {
				buttonLeft.SetActive (true);
				buttonRight.SetActive (true);
			}
			if(leftInput == true) {
				_stateNum = 2;
				leftInput = false;
				ButtonOut();
			}
			if(rightInput == true) {
				_stateNum = 1;
				rightInput = false;
				ButtonOut();
			}break;
		case 1: // going right at point #1
			MoveThisWay("marker66", RIGHT_ROTATE, "marker68", RIGHT_ROTATE);
			break;
		case 2: // going left at point #1
			MoveThisWay("marker66", LEFT_ROTATE, "marker62", NO_ROTATION);
			break;
		default: 
			break;
		}
		instruction.target = markerFinder.transform.position;
		instruction.status = 0;
	}

	//structure of instruction
	public struct InsTructions {
		public Vector3 target; // target position
		public int rotation; // 1 is right, 2 is left, 0 is none
		public int status; // 0 is moving, 1 is choosing, 2 is none
		public bool rotationFin; //false not done, true done
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

	//moving method overloading
	public void MoveThisWay(string des1, int rot1, string des2, int rot2) {
		this.markerFinder = GameObject.Find (des1); //1st destination, current destination
		this.markerFinder2 = GameObject.Find (des2); //2nd destination
		switch(this.stageJumper) {
		case 0: 
			if((Vector3.Distance (this.player.transform.position, this.markerFinder.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot1; //do first rotation
				this.instruction.rotationFin = false;
				this.stageJumper = 1;
			}
			break;
		case 1: 
			this.markerFinder = this.markerFinder2;
			if((Vector3.Distance (this.player.transform.position, this.markerFinder.transform.position) < 0.0001f)) {
				this.instruction.rotation = rot2; //do second rotation
				this.instruction.rotationFin = false;
				this.stageJumper = 2;
			}
			break;
		case 2:
			this.markerFinder = this.markerFinder2;
			break;
		default:
			break;
		}
		//Debug.Log (Vector3.Distance (player.transform.position, markerFinder2.transform.position));
	}
}