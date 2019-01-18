using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{

    public static Vector3 DirectionTo(this Vector3 source, Vector3 target) {
        return Vector3.Normalize(target - source);
    }

    public static Vector3 WithValues(this Vector3 original, float? x = null, float? y = null, float? z = null) {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }
    
}
