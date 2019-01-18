using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions 
{

    public static Vector3 DirectionTo(this Transform source, Vector3 target) {
        return source.position.DirectionTo(target);
    }
    
    public static Vector3 DirectionTo(this Transform source, Transform target) {
        return source.position.DirectionTo(target.position);

    }
    
}
