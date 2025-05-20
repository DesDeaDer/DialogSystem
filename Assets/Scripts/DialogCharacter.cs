using System;
using UnityEngine;

public class DialogCharacter : MonoBehaviour {
    readonly int _hashIsActive = Animator.StringToHash("Blend");

    [SerializeField] Transform _nameTransform;
    [SerializeField] Animator _animator;

    public Vector3 NamePositiion => _nameTransform.position;

    public void Hide() 
        => gameObject.SetActive(false);

    public void Show()
        => gameObject.SetActive(true);

    public void SetState(SpeechCharacterStateID stateID) {
        if (stateID == SpeechCharacterStateID.Active:
            SetStateActive();
        if (stateID == SpeechCharacterStateID.Passive:
            SetStatePassive();
    }

    void SetStatePassive()
        => _animator.SetFloat(_hashIsActive, 0);

    void SetStateActive()
        => _animator.SetFloat(_hashIsActive, 1);
}
