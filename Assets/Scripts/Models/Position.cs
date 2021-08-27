using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public Vector3 position;

    public Position(int row, int col) {
        this.position = new Vector3(row, col, 0);
    }

    public Position(Vector3 vector) {
        this.position = vector;
    }
}
