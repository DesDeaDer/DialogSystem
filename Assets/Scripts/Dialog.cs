using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    [SerializeField] ProviderCharacters _providerCharacters;
    [SerializeField] TextLocalizator _providerTexts;
    [SerializeField] Text _textUI;
    [SerializeField] Transform _charactersContainer;

    [SerializeField] GameObject _nameCharacterObject;
    [SerializeField] Text _nameCharacterText;

    readonly Dictionary<DialogCharacterID, DialogCharacter> _charactersCashe = new Dictionary<DialogCharacterID, DialogCharacter>();

    IEnumerator<SpeechData> _speechIterator;

    void ShowCharacterName(CharacterData data, DialogCharacter character) {
        _nameCharacterObject.SetActive(true);
        _nameCharacterObject.transform.position = GetNamePositiion(character);
        _nameCharacterText.text = _providerTexts[data.NameID];
    }

    Vector3 GetNamePositiion(DialogCharacter character) {
        var result = character.NamePositiion;
        result.y = _nameCharacterObject.transform.position.y;
        return result;
    }

    void HideCharacterName()
        => _nameCharacterObject.SetActive(false);

    public void BeginDialog(DialogData data) {
        _speechIterator = data.Speeches.GetEnumerator();

        Show();
        ShowNextSpeech();
    }

    public void ShowNextSpeech() {
        if (_speechIterator.MoveNext())
            SetSpeech(_speechIterator.Current);
        else
            EndDialog();
    }

    void SetSpeech(SpeechData speechData) {
        var speechText = _providerTexts[speechData.TextID];

        SetText(speechText);
        AddCharacters(speechData.Characters);
    }

    public void EndDialog()
        => Hide();

    void SetText(string value)
        => _textUI.text = value;

    void AddCharacters(IEnumerable<CharacterData> characters) {
        RemoveCharacters();

        foreach (var item in characters)
            AddCharacter(item);
    }

    void RemoveCharacters() {
        foreach (var item in _charactersCashe.Values)
            item.Hide();
    }

    void AddCharacter(CharacterData data) {
        var character = GetCharacter(data.CharacterID);

        if (data.StateID == SpeechCharacterStateID.Active)
            ShowCharacterName(data, character);

        character.SetState(data.StateID);
    }

    DialogCharacter GetCharacter(DialogCharacterID characterID) {
        if (!_charactersCashe.TryGetValue(characterID, out var result)) {
            var characterRef = _providerCharacters[characterID];
            var characterInstance = Instantiate(characterRef, _charactersContainer, false);

            _charactersCashe.Add(characterID, characterInstance);

            result = characterInstance;
        }

        result.Show();

        return result;
    }

    void Show()
        => gameObject.SetActive(true);

    void Hide()
        => gameObject.SetActive(false);
}
