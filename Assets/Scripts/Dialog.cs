using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    [SerializeField] private ProviderCharacters _providerCharacters;
    [SerializeField] private TextLocalizator _providerTexts;
    [SerializeField] private Text _textUI;
    [SerializeField] private Transform _charactersContainer;

    [SerializeField] private GameObject _nameCharacterObject;
    [SerializeField] private Text _nameCharacterText;

    private readonly Dictionary<DialogCharacterID, DialogCharacter> _charactersCashe = new Dictionary<DialogCharacterID, DialogCharacter>();

    private IEnumerator<SpeechData> _speechIterator;

    private void ShowCharacterName(CharacterData data, DialogCharacter character)
    {
        _nameCharacterObject.SetActive(true);
        _nameCharacterObject.transform.position = character.NamePositiion;
        _nameCharacterText.text = _providerTexts[data.NameID];
    }

    private void HideCharacterName()
    {
        _nameCharacterObject.SetActive(false);
    }

    public void BeginDialog(DialogData data)
    {
        _speechIterator = data.Speeches.GetEnumerator();

        Show();
        ShowNextSpeech();
    }

    public void ShowNextSpeech()
    {
        if (_speechIterator.MoveNext())
        {
            SetSpeech(_speechIterator.Current);
        }
        else
        {
            EndDialog();
        }
    }

    private void SetSpeech(SpeechData speechData)
    {
        var speechText = _providerTexts[speechData.TextID];

        SetText(speechText);
        AddCharacters(speechData.Characters);
    }

    public void EndDialog()
    {
        Hide();
    }

    private void SetText(string value)
    {
        _textUI.text = value;
    }

    private void AddCharacters(IEnumerable<CharacterData> characters)
    {
        RemoveCharacters();

        foreach (var item in characters)
        {
            AddCharacter(item);
        }
    }

    private void RemoveCharacters()
    {
        foreach (var item in _charactersCashe.Values)
        {
            item.Hide();
        }
    }

    private void AddCharacter(CharacterData data)
    {
        var character = GetCharacter(data.CharacterID);

        if (data.StateID == SpeechCharacterStateID.Active)
        {
            ShowCharacterName(data, character);
        }

        character.SetState(data.StateID);
    }

    private DialogCharacter GetCharacter(DialogCharacterID characterID)
    {
        DialogCharacter result;
        if (!_charactersCashe.TryGetValue(characterID, out result))
        {
            var characterRef = _providerCharacters[characterID];
            var characterInstance = Instantiate(characterRef, _charactersContainer, false);

            _charactersCashe.Add(characterID, characterInstance);

            result = characterInstance;
        }

        result.Show();

        return result;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
