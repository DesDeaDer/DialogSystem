using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpeechData {
    [SerializeField] private TextID _textID;
    [SerializeField] private CharacterData[] _characters;

    public TextID TextID => _textID;
    public IEnumerable<CharacterData> Characters => _characters;
}
