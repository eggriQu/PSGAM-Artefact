using UnityEngine;

[CreateAssetMenu(menuName = "State/Player/Neutral Air")]
public class PlayerAir : BaseState
{
    public override void Entry(BaseController controller)
    {
        Debug.Log("Player Jump");

        if (controller.isDashing)
        {
            controller.isDashing = false;
        }

        if (controller.isGrounded)
        {
            controller.rb.linearVelocityY = 0f;
            controller.rb.AddForceY(controller.jumpForce, ForceMode2D.Impulse);
            controller.isAirborne = true;
        }
        else
        {

        }
    }

    public override void UpdatePhysics(BaseController controller)
    {
        if (controller.actionCoroutine == null)
        {
            controller.rb.linearVelocityX = controller.followDirection.x * controller.moveSpeed;

            if (controller.rb.linearVelocityY <= 0f)
            {
                controller.isFalling = true;
                controller.rb.gravityScale = controller.fallingGravity;
            }
            else
            {
                controller.rb.gravityScale = controller.groundedGravity;
            }
        }
        else
        {
            
        }
    }

    public override void UpdateLogic(BaseController controller)
    {
        controller.ChangeUsingTransition();
    }

    public override void Exit(BaseController controller)
    {
        controller.isFalling = false;
    }
}
