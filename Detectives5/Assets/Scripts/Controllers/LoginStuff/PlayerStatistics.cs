using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerStatistics
{

    public int etapaActual { set; get; }
    public float positionX { set; get; }
    public float positionY { set; get; }
    public float positionZ { set; get; }
    public DateTime lastDateTime { set; get; }
    public float points { set; get; }
    public float gameTime { set; get; }

}