using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Debug.Log("Crash!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We have hit a trigger!");
    }
}
