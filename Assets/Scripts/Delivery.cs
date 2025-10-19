using UnityEngine;

public class Delivery : MonoBehaviour
{
    string _packageTag = "Package";
    string _customerTag = "Customer";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_packageTag))
        {
            Debug.Log("We picked it up!");
        }
        else if (collision.CompareTag(_customerTag))
        {
            Debug.Log("The package has been delivered to the customer!");
        }
        
    }
}
