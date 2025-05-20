using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TextLocalizator_", menuName = "Create/Data/Text localizator")]
public class TextLocalizator : ScriptableObject {
    [SerializeField] private Data[] _data;

    [Serializable]
    struct Data {
        [SerializeField] private TextID _id;
        [SerializeField] private string _text;

        public TextID ID => _id;
        public string Text => _text;
    }

    public string this[TextID id]
        => _data.First(d => d.ID == id);
}
