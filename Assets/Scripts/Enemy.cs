using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BanditPlayerController
{
    enum Axis
    {
        Horizontal,
        Vertical,

    }

    [SerializeField] private Axis axis;

    private Vector2 dir;

    private void Awake()
    {
        dir = (axis == Axis.Vertical) ? Vector2.up : Vector2.right;
    }

    private void Update()
    {
        if (Raycast(dir) && !isMovement) dir *= -1f;
        MovePlayerTo(dir);
    }
}
