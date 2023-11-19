using UnityEngine;

public class Enemy_Pathfinding : MonoBehaviour
{
    

    private bool shouldTurnRight = false;
    private bool shouldTurnLeft = false;
    private bool shouldTurnDown = false;
    private bool shouldTurnUp = false;
    private bool shouldTurnLU = false;
    private bool shouldTurnRU = false;

    private bool initialMovement = true;

    private bool isMovingRight = false;

    private GameObject finish_Line;
    private Monster monster;



    private float speed = 1.0f;

    private void Start()
    {
        finish_Line = GameObject.Find("FinishLine_Node");


        monster = gameObject.GetComponent<Monster>();



        Vector3 newPos = transform.position + Vector3.up * speed * Time.deltaTime;


        transform.position = newPos;
    }

    private void Update()
    {
        if (initialMovement)
        {
            Vector3 newPos = transform.position + Vector3.up * speed * Time.deltaTime;

            transform.position = newPos;
        }
        
        if (shouldTurnRight)
        {
            initialMovement = false;
            RightMove();
        }
        else if (shouldTurnUp)
        {
            initialMovement = false;
            UpwardMove();
        }
        else if (shouldTurnLeft)
        {
            initialMovement = false;
            LeftMove();
        }
        else if(shouldTurnLU)
        {
            initialMovement = false;
            DiagonalUpLeft();
        }
        else if (shouldTurnRU)
        {
            initialMovement = false;
            DiagonalUpRight();
        }
    }

    private void UpwardMove()
    {
        Vector3 upDirection = transform.up;
        Vector3 newPos = transform.position + upDirection * speed * Time.deltaTime;

        newPos.x = transform.position.x;

        transform.position = newPos;
        monster.RotateUp();
    }

    private void RightMove()
    {
        Vector3 rightDirection = Vector3.right; // Use Vector3.right to move only to the right
        Vector3 movement = rightDirection * speed * Time.deltaTime;

        // Update the GameObject's position
        transform.position += movement;
        monster.RotateR(); // Call a method to handle rotation if needed
    }

    private void LeftMove()
    {
        Vector3 leftDirection = -transform.right;
        Vector3 newPos = transform.position + leftDirection * speed * Time.deltaTime;



        newPos.y = transform.position.y;
        transform.position = newPos;
        monster.RotateL();
    }

    private void DownMove()
    {
        Vector3 newPos = transform.position + Vector3.down * speed * Time.deltaTime;
        transform.position = newPos;
    }

    private void DiagonalUpLeft()
    {
        Vector3 movement = (Vector3.up - Vector3.right) * speed * Time.deltaTime;

        // Update the GameObject's position
        transform.position += movement;
        monster.RotateUL();
    }

    private void DiagonalUpRight()
    {
        Vector3 movement = (Vector3.up + Vector3.right) * speed * Time.deltaTime;

        // Update the GameObject's position
        transform.position += movement;
        monster.RotateUR();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collidedObjectName = collision.gameObject.name;

        // Compare collided object's name with the names of the nodes
        if (collision.gameObject.tag == "R_Node")
        {
            shouldTurnUp = false;
            shouldTurnLeft = false;
            shouldTurnRight = true;
            
            //Debug.Log("Turn Right");
        }
        else if (collision.gameObject.tag == "U_Node")
        {
            shouldTurnLeft = false;
            shouldTurnRight = false;
            shouldTurnUp = true;

            //Debug.Log("Turn Up");
        }
        else if (collision.gameObject.tag == "L_Node")
        {
            shouldTurnRight = false;
            shouldTurnUp = false;
            shouldTurnLeft = true;

            //Debug.Log("Turn Left");
        }
        else if (collision.gameObject.tag == "LU_Node")
        {
            shouldTurnRight = false;
            shouldTurnUp = false;
            shouldTurnLeft = false;
            shouldTurnLU = true;

            //Debug.Log("Turn Diagonal Left Up");
        }
        else if (collision.gameObject.tag == "RU_Node")
        {
            shouldTurnRight = false;
            shouldTurnUp = false;
            shouldTurnLeft = false;
            shouldTurnLU = false;
            shouldTurnRU = true;

            //Debug.Log("Turn Diagonal Right Up");
        }
        else if(collision.gameObject.tag == "Finish_Line")
        {
            Debug.Log("Finish!");
            monster.CrossLine();

            Destroy(gameObject);
        }
    }

    
}
