using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    string _packageTag = "Package";
    string _customerTag = "Customer";
    bool _hasPackage;

    [SerializeField]
    float _destroyDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_packageTag) && _hasPackage == false)
        {
            Debug.Log("We picked it up!");
            _hasPackage = true;
            Destroy(collision.GameObject(), _destroyDelay);

        }
        else if (collision.CompareTag(_customerTag) && _hasPackage)
        {
            Debug.Log("The package has been delivered to the customer!");
            _hasPackage = false;
        }
    }
}
