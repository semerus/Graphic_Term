using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public Vector3 wallPosition;
	public GameObject wallPrefab;
	//private int x = 10;
	//private int y = 5;
	//private ArrayList = new ArrayList();
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
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};


	// Use this for initialization
	void Start () {
		//Instantiate (wallPrefab, wallPosition, Quaternion.identity);
		Vector3 position;
		for (int i; i<10; i++)
		{
			for (int j; j<10; j++)
			{
				if(_grid[i,j] == 1)
				{
					position.Set(GridConverter(i,j));
					Instantiate(wallPrefab, position, Quaternion.identity);
				}
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Vector3 GridConverter(int x, int y)
	{
		Vector3 position;
		float vx, vz;
		vx = -4.5f + (float)y;
		vz = -4.5f + (float)x;
		position.Set (vx, 0.5f, vz);
		return position;
	}
}

/* maze structure 0=space, 1=wall, 2=playerstart
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