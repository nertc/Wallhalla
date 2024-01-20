using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationSpeed = 2f;
    public float brakeSpeed = 1.15f;
    public float turnSpeed = 20f;
    public float horizontalInput;
    public float forwardInput;
    public float currentSpeed = 20f;
    public float minCurrentSpeed = 10f;
    public float maxCurrentSpeed = 40f;
    public float minmaxAcceleration = 0.001f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, Time.deltaTime * this.turnSpeed * this.horizontalInput);
        float y = (transform.eulerAngles.y + 360) % 360;
        if (y > 180)
        {
            y -= 360;
        }
        y = Math.Min(80f, Math.Max(-80f, y));

        transform.eulerAngles = new Vector3(0, y, 0);
        if (this.forwardInput < 0)
        {
            this.currentSpeed += (currentSpeed - minCurrentSpeed) / brakeSpeed * Time.deltaTime * forwardInput;
        }
        if (this.forwardInput > 0)
        {
            this.currentSpeed += (maxCurrentSpeed - currentSpeed) / accelerationSpeed * Time.deltaTime * forwardInput;
        }
        this.currentSpeed = Math.Max(currentSpeed, this.minCurrentSpeed);
        this.currentSpeed = Math.Min(currentSpeed, this.maxCurrentSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * this.currentSpeed);
        minCurrentSpeed += minmaxAcceleration * Time.deltaTime;
        maxCurrentSpeed += minmaxAcceleration * Time.deltaTime;
    }
}
