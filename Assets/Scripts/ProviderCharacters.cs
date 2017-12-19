using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProviderCharacters_", menuName = "Create/Data/Provider characters")]
public class ProviderCharacters : ScriptableObject
{
    [SerializeField] private Data[] _data;

    [Serializable]
    private struct Data
    {
        [SerializeField] private DialogCharacterID _id;
        [SerializeField] private DialogCharacter _character;

        public DialogCharacterID ID
        {
            get
            {
                return _id;
            }
        }

        public DialogCharacter Character
        {
            get
            {
                return _character;
            }
        }
    }

    public DialogCharacter this[DialogCharacterID id]
    {
        get
        {
            foreach (var item in _data)
            {
                if (item.ID == id)
                {
                    return item.Character;
                }
            }

            throw new ArgumentException();
        }
    }
}
