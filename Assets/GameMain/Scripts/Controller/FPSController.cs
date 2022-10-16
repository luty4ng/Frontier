using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public bool IsLockCursor;
    public float MouseSensitivity = 10;
    public float WalkSpeed = 3;
    public float RunSpeed = 6;
    public float JumpForce = 8;
    public float Gravity = 18;
    [Tooltip("The sensitivity between input and moving"), Range(0f, 0.25f)]
    public float MoveSmoothTime = 0.1f;
    [Tooltip("The sensitivity between input and rotating"), Range(0f, 0.25f)]
    public float RotationSmoothTime = 0.1f;
    public Vector2 PitchMinMax = new Vector2(-40, 85);
    [Space]
    [SerializeField] private float yaw;
    [SerializeField] private float pitch;

    CharacterController controller;
    Camera cam;
    float smoothYaw;
    float smoothPitch;
    float yawSmoothV;
    float pitchSmoothV;
    float verticalVelocity;
    Vector3 velocity;
    Vector3 smoothV;

    bool jumping;
    float lastGroundedTime;

    void Start()
    {
        cam = Camera.main;
        if (IsLockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        controller = GetComponent<CharacterController>();
        yaw = transform.eulerAngles.y;
        pitch = cam.transform.localEulerAngles.x;
        smoothYaw = yaw;
        smoothPitch = pitch;
    }

    void Update()
    {

        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        else
        {
            if (IsLockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 dir = new Vector3(input.x, 0, input.y).normalized;
        Vector3 worldInputDir = transform.TransformDirection(dir);

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
        Vector3 targetVelocity = worldInputDir * currentSpeed;
        velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothV, MoveSmoothTime);

        verticalVelocity -= Gravity * Time.deltaTime;
        velocity = new Vector3(velocity.x, verticalVelocity, velocity.z);

        var flags = controller.Move(velocity * Time.deltaTime);
        if (flags == CollisionFlags.Below)
        {
            jumping = false;
            lastGroundedTime = Time.time;
            verticalVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastTouchedGround = Time.time - lastGroundedTime;
            if (controller.isGrounded || (!jumping && timeSinceLastTouchedGround < 0.15f))
            {
                jumping = true;
                verticalVelocity = JumpForce;
            }
        }

        float mX = Input.GetAxisRaw("Mouse X");
        float mY = Input.GetAxisRaw("Mouse Y");
        float mMag = Mathf.Sqrt(mX * mX + mY * mY);
        if (mMag > 5)
        {
            mX = 0;
            mY = 0;
        }

        yaw += mX * MouseSensitivity;
        pitch -= mY * MouseSensitivity;
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);
        smoothPitch = Mathf.SmoothDampAngle(smoothPitch, pitch, ref pitchSmoothV, RotationSmoothTime);
        smoothYaw = Mathf.SmoothDampAngle(smoothYaw, yaw, ref yawSmoothV, RotationSmoothTime);

        transform.eulerAngles = Vector3.up * smoothYaw;
        cam.transform.localEulerAngles = Vector3.right * smoothPitch;

    }
}