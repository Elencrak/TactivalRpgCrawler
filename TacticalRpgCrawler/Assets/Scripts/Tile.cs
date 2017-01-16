using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool blocked;
    public Vector2 position2D;
    public EntityController entity = null;

    public Texture floor;
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyWall()
    {
        GetComponent<MeshRenderer>().material.mainTexture = floor;

        blocked = false;
    }
}
