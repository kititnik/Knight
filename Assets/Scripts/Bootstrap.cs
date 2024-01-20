using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    private PlayerMovement _playerMovement;


    void Awake()
    {
        _playerMovement = new PlayerMovement(_playerObject.GetComponent<SpriteRenderer>(),
            _playerObject.GetComponent<Rigidbody2D>(), _playerObject.GetComponent<Animator>());
        _playerObject.GetComponent<Player>().Inititialize(_playerMovement);
    }
}
