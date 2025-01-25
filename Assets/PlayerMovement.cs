using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedMovement;
    [SerializeField] float speedRotation;
    [SerializeField] float smoothMovement;
    [SerializeField] KeyCode player1InputRight;
    [SerializeField] KeyCode player1InputLeft;
    [SerializeField] KeyCode player2InputRight;
    [SerializeField] KeyCode player2InputLeft;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey(player1InputLeft) && !Input.GetKey(player1InputRight))
        {
            float angle = transform.rotation.eulerAngles.z;
            float currentAngle = angle += Time.deltaTime * speedRotation * 10;
            rb.MoveRotation(currentAngle);
            rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, transform.up * speedMovement, smoothMovement * Time.deltaTime);

        }
        if (Input.GetKey(player1InputRight) && !Input.GetKey(player1InputLeft))
        {
            float angle = transform.rotation.eulerAngles.z;
            float currentAngle = angle -= Time.deltaTime * speedRotation * 10;
            rb.MoveRotation(currentAngle);
            rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, transform.up * speedMovement, smoothMovement * Time.deltaTime);

        }
        if (Input.GetKey(player1InputLeft) && Input.GetKey(player1InputRight))
        {
            rb.linearVelocity = transform.up * speedMovement;
        }
        if (!Input.GetKey(player1InputLeft) && !Input.GetKey(player1InputRight))
        {
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, Vector2.zero, smoothMovement * Time.deltaTime);
        }
        
        
    }

}

