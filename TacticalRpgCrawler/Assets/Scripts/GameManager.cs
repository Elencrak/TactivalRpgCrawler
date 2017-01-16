using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject[,] map;
    public Transform parent;

    public GameObject wall;
    public GameObject floor;

    public int width;
    public int height;

	// Use this for initialization
	void Start () {
        map = new GameObject[width, height];

		for (int i = 0; i < width; i ++ )
        {
            for(int j = 0; j < height; j++)
            {
                GameObject temp;       
                if(i == 0 && j  == 0)
                {
                    temp = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    temp.transform.parent = parent;
                }
                else
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        temp = Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                        temp.transform.parent = parent;
                    }
                    else
                    {
                        temp = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                        temp.transform.parent = parent;
                    }
                }

                map[i, j] = temp;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
