using System;
using UnityEngine;

public class DialogCharacter : MonoBehaviour
{
    private readonly int _hashIsActive = Animator.StringToHash("Blend");

    [SerializeField] private Transform _nameTransform;
    [SerializeField] private Animator _animator;

    public Vector3 NamePositiion
    {
        get
        {
            return _nameTransform.position;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetState(SpeechCharacterStateID stateID)
    {
        switch (stateID)
        {
            case SpeechCharacterStateID.Active:
                SetStateActive();
                break;
            case SpeechCharacterStateID.Passive:
                SetStatePassive();
                break;
        }
    }

    private void SetStatePassive()
    {
        _animator.SetFloat(_hashIsActive, 0);
    }

    private void SetStateActive()
    {
        _animator.SetFloat(_hashIsActive, 1);
    }
}
