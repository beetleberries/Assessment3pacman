using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class PacStudentController : MonoBehaviour
{
    public AudioSource audioplayer;

    public Animator animator;

    public LevelGenerator level;

    private Vector3 position;
    private Vector3 nextposition;
    public float movedpercent;
    public float movespeed;
    private int target = 0;

    private Vector3 lastInput = Vector3.right;
    private Vector3 currentInput = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        nextposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        getinput();
        move();
        changemove();
    }
    private void changemove()
    {
        if (movedpercent < 1) return; //if finished moving

        Vector3Int levelcoords = Vector3Int.FloorToInt(nextposition + lastInput);
        int levelint = level.readMap(-levelcoords.y,levelcoords.x);

        if (levelint >= 5 || levelint == 0) 
        {
            animator.SetInteger("direction", target);
            currentInput = lastInput;
        }

        levelcoords = Vector3Int.FloorToInt(nextposition + currentInput);
        levelint = level.readMap(-levelcoords.y,levelcoords.x);

        if (levelint < 5 && levelint != 0) 
        {
            animator.SetFloat("animationspeed", 0);
            audioplayer.mute = true;
            return;
        }

        animator.SetFloat("animationspeed", 1);
        audioplayer.mute = false;
        position = nextposition;
        nextposition = nextposition + currentInput;
        movedpercent = 0;
    }

    private void getinput()
    {
        if (Input.GetKeyDown(KeyCode.W)) {lastInput = Vector3.up; target = 3;}
        if (Input.GetKeyDown(KeyCode.S)) {lastInput = Vector3.down; target = 1;}
        if (Input.GetKeyDown(KeyCode.A)) {lastInput = Vector3.left; target = 2;}
        if (Input.GetKeyDown(KeyCode.D)) {lastInput = Vector3.right; target = 0;}
        
    }

    private void move()
    {
        movedpercent += movespeed;
        if (movedpercent > 1)
        {
            transform.position = nextposition;
            return;
        }
        transform.position = Vector3.Lerp(position, nextposition, movedpercent);
    } 
}
