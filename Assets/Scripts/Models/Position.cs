using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Position: IEquatable<Position>
{
    public Vector3 position;

    public Position(int row, int col) {
        this.position = new Vector3(row, col, 0);
    }

    public Position(Vector3 vector) {
        this.position = vector;
    }

    public override int GetHashCode()
    {
        return position.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Position);
    }

    public bool Equals(Position obj) {
        return obj != null && obj.position == this.position;
    }
}
