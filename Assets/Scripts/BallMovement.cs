using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody ball;
    public float minSpeed = 10f;
    public float maxSpeed = 50f;
    private float startTime;
    private Vector2 startPos;
    private bool isBallTouched = false;

    void Start()
    {
        // Set the ball's initial velocity to zero so it doesn't fall before touch input
        ball.velocity = Vector3.zero;
        isBallTouched = false;
    }

    void Update()
    {
        MoveBall();
    }

    void OnCollisionEnter(Collision other)
    {
        isBallTouched = true;
    }
    
    void MoveBall()
    {
        if (Input.touchCount > 0 && isBallTouched)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                startTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 endPos = touch.position;
                float endTime = Time.time;

                float speed = (endPos - startPos).magnitude / (endTime - startTime);
                speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

                Vector3 direction = (endPos - startPos).normalized;
                direction.z = direction.y;
                direction.y = (endPos.y - startPos.y) / Screen.height;
                ball.AddForce(direction * speed, ForceMode.Impulse);
            }
        }        
    }
}

