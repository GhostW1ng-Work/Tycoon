using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _mover.MovementChanged += OnMovementChange;
    }

    private void OnDisable()
    {
        _mover.MovementChanged -= OnMovementChange;
    }

    private void OnMovementChange(bool isMovementChanged)
    {
        _animator.SetBool("IsRun", isMovementChanged);
    }
}
