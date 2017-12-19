﻿using System;
using UnityEngine;

[Serializable]
public class CharacterData
{

    [SerializeField] private DialogCharacterID _characterID;
    [SerializeField] private TextID _nameID;
    [SerializeField] private SpeechCharacterStateID _stateID;

    public DialogCharacterID CharacterID
    {
        get
        {
            return _characterID;
        }
    }

    public SpeechCharacterStateID StateID
    {
        get
        {
            return _stateID;
        }
    }

    public TextID NameID
    {
        get
        {
            return _nameID;
        }
    }

}
