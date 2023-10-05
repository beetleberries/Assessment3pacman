using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmovement : MonoBehaviour
{
    public Animator animator;

    Vector3[] positions = new Vector3[4];

    public int target;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        positions[0] = new Vector3(0f,0f,0f);			
        positions[1] = new Vector3(3f,0f,0f);
        positions[2] = new Vector3(3f,3f,0f);
        positions[3] = new Vector3(0f,3f,0f);
        target = 0;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[target], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, positions[target]) < 0.1f)
        {
            target = (target + 1) % 4;
            animator.SetInteger("direction", target);
        }

    }
}
