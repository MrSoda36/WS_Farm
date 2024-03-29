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

    /// <summary>
    /// Handle the player movement.
    /// Unity function called by the Input System.
    /// </summary>
    /// <param name="value">Value from the Player's input.</param>
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        _rb.velocity = direction * _speed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
