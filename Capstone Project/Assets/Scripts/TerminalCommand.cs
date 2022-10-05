using UnityEngine;

[System.Serializable]
public class TerminalCommand
{
    public InputOutputPair[] IOPairs;
    public string CommandName;
    public string InvalidArgsMessage;

    public static TerminalCommand GetFromJson(string jsonString) {
        return JsonUtility.FromJson<TerminalCommand>(jsonString);
    }

    public string ProcessCommandInput(string input) {
        foreach (var pair in IOPairs) {
            if (pair.ExpectedInput.Equals(input))
                return pair.Output;
        }

        return CommandName + ": " + InvalidArgsMessage;
    }
}
