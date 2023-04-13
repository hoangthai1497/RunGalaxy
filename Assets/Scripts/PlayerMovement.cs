using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Swipe
{
    left,
    mid,
    right
}

public class PlayerMovement : MonoBehaviour
{
    public Swipe swipeDirec = Swipe.mid;


    //private bool isTurnleft;
    //private bool isTurnright;
    private bool SwipeLeft;
    private bool SwipeRight;
    private bool SwipeDown;
    private bool SwipeUp;
    [HideInInspector]
    public float xDirect = 2;
    [HideInInspector]
    public float xNewPos = 0;
    public float yNewPos;
    public bool isJump;
    public bool isRoll;
    //public float speed;
    [HideInInspector]
    public float xPosition;
    public float speedFwd;
    public float jumpForce;
    private CharacterController m_Char;
    private Animator m_Animator;
    void Start()
    {
        m_Char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();

    }


    void Update()
    {
        MoveController();
        Jump();
        Slide();
    }

    #region MOVE_LEFT_RIGHT
    public void MoveController()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.S);
        #region Turn_
        //isTurnleft = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl);
        //isTurnright = Input.GetKeyDown (KeyCode.RightShift)|| Input.GetKeyDown(KeyCode.RightControl);

        //if (isTurnleft)
        //{
        //    transform.Rotate(new Vector3(0, -90, 0));
        //}
        //else if (isTurnright)
        //{ 
        //    transform.Rotate(new Vector3(0, 90, 0));
        //}
        #endregion
        if (SwipeLeft)
        {
            if (swipeDirec == Swipe.mid)
            {
                xNewPos = xDirect * (-1);
                swipeDirec = Swipe.left;
               
            }
            else if (swipeDirec == Swipe.right)
            {
                xNewPos = 0;
                swipeDirec = Swipe.mid;
                
            }
        }
        else if (SwipeRight)
        {
            if (swipeDirec == Swipe.mid)
            {
                xNewPos = xDirect;
                swipeDirec = Swipe.right;
                
            }
            else if (swipeDirec == Swipe.left)
            {
                xNewPos = 0;
                swipeDirec = Swipe.mid;
                
            }
        }
        xPosition = xNewPos - transform.position.x;
        xPosition = Mathf.Lerp(xPosition,xNewPos, speedFwd * Time.deltaTime);

        Vector3 vectorMove = new Vector3(xPosition, yNewPos * Time.deltaTime, speedFwd * Time.deltaTime);
        //Vector3 vectorHorizontal = new Vector3(xPosition,0,0);
        m_Char.Move(vectorMove);
        //transform.Translate(transform.forward);
    }
    #endregion

    public void Jump()
    {
        SwipeUp = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
        if (m_Char.isGrounded)
        {
            if (SwipeUp)
            {
                yNewPos = jumpForce;
                m_Animator.CrossFadeInFixedTime("Jump", 0.1f);

                isJump = true;
            }
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {
                m_Animator.Play("Landing");
                isJump = false;
            }
        }
        else
        {
            yNewPos -= jumpForce * 2 * Time.deltaTime;
            if (m_Char.velocity.y < -0.1f)
            {
                //m_Animator.Play("Falling");
            }
        }
    }
    internal float CoundownRoll;
    public void Slide()
    {
        SwipeDown = Input.GetKeyDown(KeyCode.DownArrow);
        CoundownRoll -= Time.deltaTime;
        if (CoundownRoll <= 0f)
        {
            CoundownRoll = 0f;
            isRoll = false;
        }

        if (SwipeDown)
        {
            CoundownRoll = 0.5f;
            yNewPos -= 10;
            m_Animator.CrossFadeInFixedTime("Slide", 0.1f);
            isRoll = true;
        }
        
    }
}
