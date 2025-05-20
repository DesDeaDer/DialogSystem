using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog_", menuName = "Create/Data/Dialog")]
public class DialogData : ScriptableObject {
    [SerializeField] private SpeechData[] _speeches;

    public IEnumerable<SpeechData> Speeches => _speeches;
}
