using System;
using UnityEngine;

[Serializable]
public class CharacterData {
    [SerializeField] private DialogCharacterID _characterID;
    [SerializeField] private TextID _nameID;
    [SerializeField] private SpeechCharacterStateID _stateID;

    public DialogCharacterID CharacterID => _characterID;
    public SpeechCharacterStateID StateID => _stateID;
    public TextID NameID => _nameID;
}
