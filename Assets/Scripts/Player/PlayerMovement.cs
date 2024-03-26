using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script to handle player movement in 2D.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5f;
    private Rigidbody2D _rb;
    [SerializeField]
    private PlayerMain _playerMain;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        _rb.velocity = direction * _speed;
    }
}
