using Unity.VisualScripting;
using UnityEngine;

namespace PlayerCharacter
{
    public class TankControlsAnimation : MonoBehaviour
    {
        private float horizontalMove;
        private float verticalMove;

        private float velocity;
        private const float GRAVITY = -9.81f;
        private float gravityMultiplier = 1.0f;

        private CharacterController controller;
        private Animator animator;


        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            ApplyGravity();
            if (GetComponent<Player>().CanMove)
            {
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;

                    Vector3 grav = new Vector3(0, velocity, 0);
                    controller.Move((transform.forward * verticalMove) + grav);
                    transform.Rotate(0, horizontalMove, 0);
                }

                if (Input.GetKey(KeyCode.W) && Input.GetButton("Vertical")) animator.SetBool("isWalkingForward", true);
                else animator.SetBool("isWalkingForward", false);

                if (Input.GetKey(KeyCode.S) && Input.GetButton("Vertical")) animator.SetBool("isWalkingBackwards", true);
                else animator.SetBool("isWalkingBackwards", false);

                if (Input.GetKey(KeyCode.D) && !Input.GetButton("Vertical")) animator.SetBool("isTurningRight", true);
                else animator.SetBool("isTurningRight", false);

                if (Input.GetKey(KeyCode.A) && !Input.GetButton("Vertical")) animator.SetBool("isTurningLeft", true);
                else animator.SetBool("isTurningLeft", false);
            }
        }

        private void ApplyGravity()
        {
            if (controller.isGrounded && velocity < 0.0f)
            {
                velocity = -1.0f;
            }
            else
            {
                velocity += GRAVITY * gravityMultiplier * Time.deltaTime;
            }

        }
    }
}