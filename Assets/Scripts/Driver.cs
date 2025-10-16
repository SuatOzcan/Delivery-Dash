using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField]float _steerSpeed = 1.0f;
    [SerializeField]float _moveSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0f;
        float steer = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            //Debug.Log("We are going forward");
            //transform.Translate(Vector2.up * _moveSpeed);
           speed = 1.0f;
        }
        else if(Keyboard.current.sKey.isPressed)
        {
            //Debug.Log("We are going backwards!");
            //transform.Translate(Vector2.down * _moveSpeed);
            speed = -1.0f;
        }
        if(Keyboard.current.dKey.isPressed)
        {
            //Debug.Log("We are going to the right!");
            //transform.Translate(Vector2.right * _moveSpeed);
            //transform.Rotate(new Vector3(0, 0, -_steerSpeed));
            steer = -1.0f;
        }
        else if(Keyboard.current.aKey.isPressed)
        {
            //Debug.Log("We are going to the left!");
            //transform.Translate(Vector2.left * _moveSpeed);
            //transform.Rotate(new Vector3(0, 0, _steerSpeed));
            steer = 1.0f;
        }

        // Rotation works with the left-hand rule.
        transform.Rotate(0f,0f,steer * _steerSpeed);
        transform.Translate(0f, speed * _moveSpeed, 0f);
    }
}
