
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
       
       body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        //Flip player when moving ledt/right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        //Set animator parmeters
        anim.SetBool("run", horizontalInput != 0);
    }
}

