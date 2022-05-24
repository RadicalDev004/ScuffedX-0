using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Circle : MonoBehaviour
{
    public int Nr;
    public int Value;
    public Type type;
    public enum Type { 
        none, 
        blue, 
        red
    }
}