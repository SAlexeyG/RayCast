using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BanditPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject tnt;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float speed = 0.5f;

    protected bool isMovement;

    // Update is called once per frame
    void Update()
    {
        if (isMovement) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MovePlayerTo(Vector2.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MovePlayerTo(Vector2.right);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            MovePlayerTo(Vector2.up);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            MovePlayerTo(Vector2.down);

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(tnt, transform.position, Quaternion.identity);
    }

    protected void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir)) return;

        isMovement = true;

        var pos = (Vector2)transform.position + dir;
        transform.DOMove(pos, speed).OnComplete(() =>
        {
            isMovement = false;
        });
    }

    protected bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);
        return hit.collider != null;
    }
}
