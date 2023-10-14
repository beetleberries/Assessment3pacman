using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsceneanimation : MonoBehaviour
{
    public Transform[] nodes;
    private Vector3 movement = new Vector3(1,1,0);
    private Camera m_camera;
    private Vector2 screenPos;
    public bool onScreenX => screenPos.x > 0f && screenPos.x < Screen.width;
    public bool onScreenY => screenPos.y > 0f && screenPos.y < Screen.height;

    public float speed;
    public float followspeed;

    // Start is called before the first frame update
    void Start()
    {
        m_camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = m_camera.WorldToScreenPoint(nodes[0].position);
        if (!onScreenX) movement.x = movement.x * -1f;
        if (!onScreenY) movement.y = movement.y * -1f;
        nodes[0].position = nodes[0].position + movement * speed;
        Transform prev = nodes[0];
        foreach(Transform t in nodes){
            t.position = Vector3.Lerp(t.position, prev.position, followspeed);
            prev = t;
        }
    }
}
