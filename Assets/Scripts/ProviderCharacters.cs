using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ProviderCharacters_", menuName = "Create/Data/Provider characters")]
public class ProviderCharacters : ScriptableObject {
    [SerializeField] private Data[] _data;

    [Serializable]
    struct Data {
        [SerializeField] private DialogCharacterID _id;
        [SerializeField] private DialogCharacter _character;

        public DialogCharacterID ID => _id;
        public DialogCharacter Character => _character;
    }

    public DialogCharacter this[DialogCharacterID id] //may be use more better mapping, for ex dictionary
        => _data.First(d => d.ID == id);
}
