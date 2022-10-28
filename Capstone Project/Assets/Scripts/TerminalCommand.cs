using System.Linq;
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

    public string ProcessCommandInput(string input)
    {
        string[] navCmd = { "ls", "cd" };

        if (!navCmd.Contains(input))
        {
            foreach (var pair in IOPairs) {
                if (pair.ExpectedInput.Equals(input))
                    return pair.Output;
            }

            return CommandName + ": " + InvalidArgsMessage;
        }

        else
        {
            OurFileSystem FileSys = prepareTestFileSystem();
            //ls
            if (input.Equals(navCmd[0]))
            {
                return FileSys.Ls();
            }

            else
            {
                var dir = input.Substring(input.IndexOf(" "));
                //cd
                return FileSys.StepIn(dir);
            }
        }
    }

    private OurFileSystem prepareTestFileSystem()
    {
        var fileSys = new OurFileSystem("root");
        fileSys.AddChildDir("docs");
        fileSys.AddChildDir("downloads");                
                
        fileSys.StepIn("docs");
        
        fileSys.AddChildDir("images");
        fileSys.AddChildDir("others");

        return fileSys;
    }
}
