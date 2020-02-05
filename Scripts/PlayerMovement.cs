using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics Component of player cube
    public Rigidbody rb;
    //Forces to set in inspector
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool isRight = false;
    private bool isLeft = false;

    private Invoker invoker;
    Command noMovement;

    void Start()
    {
        invoker = new Invoker();
        noMovement = new NoMovement();
        invoker.SetCommand(noMovement, Time.timeSinceLevelLoad);
    }

    // FixedUpdate is called evenly across framerates
    void FixedUpdate()
    {
        if (Input.GetKeyDown("d"))
        {
            Command moveRight = new MoveRight(rb, sidewaysForce);
            invoker.SetCommand(moveRight, Time.timeSinceLevelLoad);
        }
        if (Input.GetKeyDown("a"))
        {
            Command moveLeft = new MoveLeft(rb, sidewaysForce);
            invoker.SetCommand(moveLeft, Time.timeSinceLevelLoad);
        }

        if (Input.GetKeyUp("d"))
        {
            invoker.Clear("D");
            //Debug.Log("D up");
        }

        if (Input.GetKeyUp("a"))
        {
            invoker.Clear("A");
            //Debug.Log("A up");
        }


        if (rb.position.y < -1f)
        {
            //End the game if the player goes off the edge
            FindObjectOfType<GameManager>().EndGame();
        }

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        invoker.ExecuteCommand();
    }
}
