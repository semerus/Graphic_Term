using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public Vector3 wallPosition;
	public GameObject wallPrefab;
	public GameObject playerPrefab;
	public GameObject markerPrefab;

	private Transform _markerHolder;
	private Transform _wallHolder;

	private int[,] _grid = new int[,] {
		{1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
		{1, 0, 0, 0, 0, 0, 0, 1, 0, 1},
		{1, 0, 1, 1, 0, 1, 1, 1, 0, 1},
		{1, 1, 1, 1, 0, 1, 0, 1, 0, 1},
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
		{1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{1, 0, 1, 1, 1, 1, 0, 1, 0, 1},
		{1, 0, 0, 0, 0, 1, 2, 1, 0, 1},
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
	};


	// Use this for initialization
	void Start () {
		Vector3 position = new Vector3();

		Destroy(GameObject.Find("MarkerGrid"));
		GameObject markerGrid = new GameObject ("MarkerGrid");
		_markerHolder = markerGrid.transform;

		Destroy(GameObject.Find("Walls"));
		GameObject walls = new GameObject ("Walls");
		_wallHolder = walls.transform;

		for (int i=0; i<10; i++) //create maze by using _grid
		{
			for (int j=0; j<10; j++)
			{
				if(_grid[i,j] == 0) { //empty spaces
					position.Set(_GridConverter(i,j).x, _GridConverter(i,j).y, _GridConverter(i,j).z);
					ObjectMaker(i, j, position, "marker",_markerHolder, markerPrefab);
				}
				if(_grid[i,j] == 1) { //create walls
					position.Set(_GridConverter(i,j).x, _GridConverter(i,j).y, _GridConverter(i,j).z);
					ObjectMaker(i, j, position, "wall", _wallHolder, wallPrefab);
					//ObjectMaker(i, j, position, "marker",_markerHolder, markerPrefab); dont need markers for walls
				}
				if(_grid[i,j] == 2) {
					position.Set(_GridConverter(i,j).x, _GridConverter(i,j).y, _GridConverter(i,j).z);
					GameObject player = Instantiate(playerPrefab, position, Quaternion.identity) as GameObject;
					player.name = "player";
					//player.transform.Rotate(0,180,0);
					ObjectMaker(i, j, position, "marker", _markerHolder, markerPrefab);
				}
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//from matrix calculate position(vector3) in world space
	private Vector3 _GridConverter(int x, int y) { 
		Vector3 position = new Vector3();
		float vx, vz;
		vx = -4.5f + (float)y;
		vz = 4.5f - (float)x;
		position.Set (vx, 0.5f, vz);
		return position;
	}

	//creates marker by receiving matrix coords and position
	public void ObjectMaker(int x, int y, Vector3 position, string name, Transform holder, GameObject prefab) {
		GameObject objectNew = Instantiate(prefab, position, Quaternion.identity) as GameObject;
		objectNew.name = name+x+y;
		objectNew.transform.SetParent (holder);
	}

}

/* maze structure ver1.0 0=space, 1=wall, 2=playerstart
{1, 1, 1, 1, 1, 1, 0, 1, 1, 1}
{1, 0, 0, 0, 0, 0, 0, 1, 0, 1}
{1, 0, 1, 1, 0, 1, 1, 1, 0, 1}
{1, 1, 1, 1, 0, 1, 0, 1, 0, 1}
{1, 0, 0, 0, 0, 0, 0, 0, 0, 1}
{1, 0, 1, 1, 1, 1, 1, 1, 1, 1}
{1, 0, 0, 0, 0, 0, 0, 0, 0, 1}
{1, 0, 1, 1, 1, 1, 0, 1, 0, 1}
{1, 0, 0, 0, 0, 1, 2, 1, 0, 1}
{1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
*/