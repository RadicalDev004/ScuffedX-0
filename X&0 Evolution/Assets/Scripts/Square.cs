using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int Value;
    public Type type = Type.none;
    public enum Type {
        none,
        blue,
        red
    }
}
