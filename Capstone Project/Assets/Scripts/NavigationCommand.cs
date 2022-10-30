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
        // Debug.Log("Cd into "+dir+" started");
        // // Debug.Log("child valid");
        FileSystem.StepInside(dir);
        // Debug.Log("Cd current dir changed to parent");
        // var pwd = "pwd = ";
        // Debug.Log("child.dir = " + currentWorkingDirectory.children);
        // Debug.Log("child.dir.length = " + currentWorkingDirectory.children.Count);
        // Debug.Log("writing pwd");
        // Debug.Log("if (currentWorkingDirectory.children.Count > 0) = " );
        // Debug.Log(truth.ToString());
        // Debug.Log("exit");
        return true;

    }

    public string Pwd()
    {
        var pwd = "Path :\n";
        while (FileSystem.HasParent())
        {
            pwd += FileSystem.getParent() + "\n";
            FileSystem.StepBack();
        }

        return pwd;
    }
    public string Ls()
    {
        Debug.Log("ls start");
            
        string ls = "Directories";

        if (FileSystem.HasChildren())
        {
            // Debug.Log("currDir = " + FileSystem.getCurrentDir());
            // Debug.Log("children array = " + FileSystem.getSubdirectories());

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