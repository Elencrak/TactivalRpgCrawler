using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : EntityController {

    bool canMove;

	// Use this for initialization
	void Start ()
    {
        canMove = true;
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
            Move(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Move(Vector2 movement)
    {
        Vector2 nextTile = new Vector2(Mathf.Clamp(position.x + movement.x, 0, GameManager.Instance.width-1),
                                        Mathf.Clamp(position.y + movement.y, 0, GameManager.Instance.height-1));

        Tile tile = GameManager.Instance.map[(int)(nextTile.x), (int)(nextTile.y)].GetComponent<Tile>();

        if (tile && !tile.blocked && tile.entity == null)
        {
            position = nextTile;

            transform.position = new Vector3(tile.transform.position.x, 1, tile.transform.position.z);
        }

        canMove = false;
        TurnManager.Instance.EndPlayerTurn();
    }

    void Attack()
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Tile tile = GameManager.Instance.map[Mathf.Clamp((int)position.x + i,0,GameManager.Instance.width), Mathf.Clamp((int)position.y + j, 0, GameManager.Instance.height)].GetComponent<Tile>();

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
