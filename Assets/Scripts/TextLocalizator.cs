using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextLocalizator_", menuName = "Create/Data/Text localizator")]
public class TextLocalizator : ScriptableObject
{

    [SerializeField] private Data[] _data;

    [Serializable]
    private struct Data
    {
        [SerializeField] private TextID _id;
        [SerializeField] private string _text;

        public TextID ID
        {
            get
            {
                return _id;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
        }
    }

    public string this[TextID id]
    {
        get
        {
            foreach (var item in _data)
            {
                if (item.ID == id)
                {
                    return item.Text;
                }
            }

            throw new ArgumentException();
        }
    }
}
