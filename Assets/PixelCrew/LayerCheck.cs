using UnityEngine;

public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundPlayer;
    private Collider2D _collider;

    public bool IsTouchingLayer;

    private void Reset()
    {
        _groundPlayer = LayerMask.GetMask("Ground", "Pushable");
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_groundPlayer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_groundPlayer);
    }
}