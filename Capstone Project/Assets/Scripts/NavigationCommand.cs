using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NavigationCommand 
{
    private readonly FileSystem FileSystem;

    public NavigationCommand(FileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }
    
    public string ProcessNavCmd(string arg, string commandName, string invalidArgsMessage)
    {
        try
        {
            switch (commandName)
            {
                case "ls":
                    return Ls();
                case "cd":
                    return Cd(arg) ? "" : invalidArgsMessage;
                case "pwd":
                    return Pwd();
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log(e);
        }

        return invalidArgsMessage;
    }
    /*
    * Cd into a dir
    */
    private bool Cd(string dir)
    {
        if (dir.Equals(".."))
        {
            FileSystem.StepBack();
            return true;
        }

        if (!FileSystem.isChildDir(dir)) return false;
        FileSystem.StepInside(dir);
        return true;

    }

    private string Pwd()
    {
        var currentDir = FileSystem.getCurrentDir();
        var pwd = currentDir;
        
        while (FileSystem.HasParent())
        {
            pwd = pwd.Insert(0,FileSystem.getParent() + " > ");
            FileSystem.StepBack();
        }
        
        //if this is too buggy we'll cd since we have the list of parents above
        FileSystem.JumpToDir(currentDir);
        return pwd;
    }
    
    private string Ls()
    {
        Debug.Log("ls start");
            
        var ls = "";

        if (FileSystem.HasChildren())
        {
            foreach (var childName in FileSystem.getSubdirectories())
            {
                if (childName != null)
                {
                    ls += "\n"+childName;
                }
            }
        }
        Debug.Log("ls success");
        return ls;
    }

    public bool IsNavCmd(string cmd)
    {
        string[] navCmd = { "ls", "cd", "pwd" };
        return navCmd.Contains(cmd);
    }
}