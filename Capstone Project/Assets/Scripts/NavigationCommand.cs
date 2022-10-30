using System.Linq;
using UnityEditor;
using UnityEngine;

public class NavigationCommand 
{
    private OurFileSystem FileSystem;

    public NavigationCommand(OurFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }
    /*
    * Cd into a dir
    */
    public bool Cd(string dir)
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

    public string Pwd()
    {
        var currentDir = FileSystem.getCurrentDir();
        var pwd = "Path : " + currentDir;
        
        while (FileSystem.HasParent())
        {
            pwd.Insert(0,FileSystem.getParent() + " > ");
            FileSystem.StepBack();
        }
        
        //if this is too buggy we'll cd since we have the list of parents above
        FileSystem.JumpToDir(currentDir);
        return pwd;
    }
    
    public string Ls()
    {
        Debug.Log("ls start");
            
        string ls = "Directories";

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

    public bool isNavCmd(string cmd)
    {
        string[] navCmd = { "ls", "cd", "pwd" };
        return navCmd.Contains(cmd);
    }
}