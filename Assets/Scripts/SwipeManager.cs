using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private static SwipeManager instance;
    public static SwipeManager Instance { get { return instance; } }
    public SwipeDirection Direction { get; set; }

    private Vector3 touchPosition;
    private float swipeResistanceX = 50f;


    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Direction = SwipeDirection.None;

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if (Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
            }
        }
    }

    public bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }
}

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2
}