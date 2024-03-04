using System;
using UnityEngine;

[Serializable]
public class Tower
{
    public string name;
    public int cost;
    public GameObject model;
    public Sprite sprite;
    
    public Tower (string _name, int _cost, GameObject _model) {
        name = _name;
        cost = _cost;
        model = _model;
    }
}
