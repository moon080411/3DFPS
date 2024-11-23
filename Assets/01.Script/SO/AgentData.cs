using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AgentData")]
public class AgentData : ScriptableObject
{
    public float speed;
    public float RunSpeed;
    public float jumpPower;
    public float BaseZoom;
    public float ZoomAmount;
    public float ZoomedSpeed;
}
