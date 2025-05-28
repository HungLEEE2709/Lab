using UnityEngine;

public class TrapMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }
    void Flip()
    {
        Vector3 scaler= transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
