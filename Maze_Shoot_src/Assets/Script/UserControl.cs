using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControl : MonoBehaviour {

	Transform playerTrans;
	Vector3 playerPosition;
	public Vector3 road;
	public Vector3 step;
	public Vector3 stepX;
	public int rotateSpeed;
	private Vector3 walk;
	private Vector3 walkCount;
	private bool go;
	private int forward = 3;
	private bool rotate = false;
	// Use this for initialization
	void Start () {
		playerTrans = GetComponent<Transform>();
		playerPosition = playerTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (forward == 2) {
			if (walkCount.z < walk.z) {
				playerTrans.Translate (step, Space.World);
				walkCount += step;
			}
			if (walkCount.z >= walk.z) {
				walk[2] = 0;
				walkCount[2] = 0;
				forward = 1;
			}
		}
		if(forward == 1)
		{
			if(rotate == false)
			{
				playerTrans.Rotate(0, 90, 0);
				rotate = true;
			}
			if(walkCount.x < walk.x)
			{
				playerTrans.Translate (stepX, Space.World);
				walkCount += stepX;
			}
			if (walkCount.x >= walk.x) {
				walk[0] = 0;
				walkCount.Set (0, 0, 0);
				forward = 3;
			}


		}
	}
	public void MoveUp(bool click)
	{
		//playerTrans.Translate (road, Space.World);
		//playerTrans.Rotate (0, 90, 0);
		walk = road;
		forward = 2;
	}
}
