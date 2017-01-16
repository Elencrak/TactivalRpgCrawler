using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : EntityController {

    bool canMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!canMove) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Move(new Vector2(1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Move(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Move(Vector2 movement)
    {
        Tile tile = GameManager.Instance.map[(int)(position.x + movement.x), (int)(position.y + movement.y)].GetComponent<Tile>();

        if (!tile.blocked)
        {
            position = position + movement;

            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y,transform.position.z);
        }

        canMove = false;
        TurnManager.Instance.EndPlayerTurn();
    }

    void Attack()
    {
        for(int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Tile tile = GameManager.Instance.map[(int)position.x + i, (int)position.y + j].GetComponent<Tile>();

                if (tile.entity != null)
                {
                    tile.entity.TakeDamage();
                }
                else if (tile.blocked)
                {
                    tile.DestroyWall();
                }
            }
        }

        canMove = false;
        TurnManager.Instance.EndPlayerTurn();
    }

    public override void TakeDamage()
    {
        SceneManager.LoadScene(0);
    }

    public override void Play()
    {
        canMove = true;
    }
}
