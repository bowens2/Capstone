using System;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class TerminalCommand
{
    public InputOutputPair[] IOPairs;
    public string CommandName;
    public string InvalidArgsMessage;
    public static FileSystem  FILE_SYSTEM = prepareTestFileSystem();
    public static TerminalCommand GetFromJson(string jsonString) {
        return JsonUtility.FromJson<TerminalCommand>(jsonString);
    }

    public string ProcessCommandInput(string input)
    {
        var navCmd = new NavigationCommand(FILE_SYSTEM);

        if (navCmd.IsNavCmd(CommandName)) return navCmd.ProcessNavCmd(input, CommandName, InvalidArgsMessage);
        foreach (var pair in IOPairs) {
            if (pair.ExpectedInput.Equals(input))
                return pair.Output;
        }

        return CommandName + ": " + InvalidArgsMessage;

    }
    
    private static FileSystem prepareTestFileSystem()
    {
        var fileSys = new FileSystem("root");
        fileSys.AddChildDir("docs");
        fileSys.AddChildDir("video");
        fileSys.AddChildDir("drive");

        fileSys.StepInside("docs");
        fileSys.AddChildDir("local");
        fileSys.AddChildDir("images");

        fileSys.GotToRoot();
        
        return fileSys;
    }
}
