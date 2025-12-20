using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    string _packageTag = "Package";
    string _customerTag = "Customer";
    string _boostTag = "Boost";
    bool _hasPackage;
    private bool _isBoosted;
    [SerializeField] 
    List<GameObject> _customersList;
    [SerializeField] 
    ParticleSystem _particle;

    [SerializeField]
    float _destroyDelay = 0.5f;
    [SerializeField]
    float _boostSpeed;
    
    [SerializeField]
    Driver _driverScript;

    [SerializeField] TMP_Text _boostText;
    [SerializeField] TMP_Text _winText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_packageTag) && _hasPackage == false)
        {
            Debug.Log("We picked it up!");
            _particle.Play();
            _hasPackage = true;
            Destroy(collision.gameObject, _destroyDelay);

        }
        else if (collision.CompareTag(_customerTag) && _hasPackage)
        {
            Debug.Log("The package has been delivered to the customer!");
            _particle.Stop();
            _hasPackage = false;
            Destroy(collision.gameObject, _destroyDelay);
            _customersList.Remove(collision.gameObject);
            if (_customersList.Count == 0)
            {
                _winText.gameObject.SetActive(true);
            }
        }

        else if (collision.CompareTag(_boostTag) && _isBoosted == false)
        {
            _driverScript._moveSpeed += _driverScript._boostSpeed;
            _isBoosted = true;
            _boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject, _destroyDelay);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isBoosted == true)
        {
            _driverScript._moveSpeed -= _driverScript._boostSpeed;
            _isBoosted = false;
            _boostText.gameObject.SetActive(false);
        }
    }
}
