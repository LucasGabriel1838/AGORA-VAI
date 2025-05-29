using UnityEngine;

public class flipper : MonoBehaviour
{
    public HingeJoint2D leftFlipper;
    public HingeJoint2D rightFlipper;
    public float motorSpeed = 1000f;
    public float motorMaxTorque = 10000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        // Controla o flipper esquerdo (A ou seta esquerda)
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            SetMotor(leftFlipper, motorSpeed);
        }
        else
        {
            SetMotor(leftFlipper, -motorSpeed);
        }

        // Controla o flipper direito (D ou seta direita)
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            SetMotor(rightFlipper, -motorSpeed);
        }
        else
        {
            SetMotor(rightFlipper, motorSpeed);
        }
    }

    void SetMotor(HingeJoint2D hinge, float speed)
    {
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = speed;
        motor.maxMotorTorque = motorMaxTorque;
        hinge.motor = motor;
        hinge.useMotor = true; // <- Isso é importante
    }
}



