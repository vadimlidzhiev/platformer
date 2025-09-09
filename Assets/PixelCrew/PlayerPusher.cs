using UnityEngine;

public class PlayerPusher : MonoBehaviour
{
    [SerializeField] private LayerCheck _pushCheck;
    public bool CanPush => _pushCheck && _pushCheck.IsTouchingLayer;
}