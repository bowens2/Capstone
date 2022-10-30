using System;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class TerminalCommand
{
    public InputOutputPair[] IOPairs;
    public string CommandName;
    public string InvalidArgsMessage;
    public OurFileSystem  FILE_SYSTEM = prepareTestFileSystem();
    public static TerminalCommand GetFromJson(string jsonString) {
        return JsonUtility.FromJson<TerminalCommand>(jsonString);
    }

    public string ProcessCommandInput(string input)
    {
        var navCmd = new NavigationCommand(FILE_SYSTEM);

        if (navCmd.isNavCmd(CommandName)) return ProcessNavCmd(input, navCmd);
        foreach (var pair in IOPairs) {
            if (pair.ExpectedInput.Equals(input))
                return pair.Output;
        }

        return CommandName + ": " + InvalidArgsMessage;

    }

    private string ProcessNavCmd(string arg, NavigationCommand navCmd)
    {
        try
        {
            //ls
            if (CommandName.Equals("ls"))
            {
                return navCmd.Ls();
            }

            //cd
            if (CommandName.Equals("cd"))
            {
                return navCmd.Cd(arg) ? "" : InvalidArgsMessage;
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log(e);
        }
        return InvalidArgsMessage;
    }

    private static OurFileSystem prepareTestFileSystem()
    {
        var fileSys = new OurFileSystem("root");
        fileSys.AddChildDir("docs");
        fileSys.AddChildDir("downloads");
        fileSys.AddChildDir("local drive");
        fileSys.AddChildDir("remote drive");

        fileSys.StepInside("docs");
        fileSys.AddChildDir("local");
        fileSys.AddChildDir("images");

        fileSys.GotToRoot();
        
        return fileSys;
    }
}
