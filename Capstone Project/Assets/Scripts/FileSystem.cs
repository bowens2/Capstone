using System;
using System.Collections.Generic;


/*
* File System class using a tree like data structure to allow the user to navigate a file structure
*/
public class FileSystem
{
    private MyNode root;
    private MyNode currentWorkingDirectory { get; set; }
        
    /*
    * The Directory tree starts with root dir that will automatically be the root dir
    */
    public FileSystem(string rootName)
    {
        root = new MyNode(null, rootName);
        currentWorkingDirectory = root;
    }
        
    public void GotToRoot()
    {
        currentWorkingDirectory = root;
    }

    public void JumpToDir(string dir)
    {
        JumpToDir(dir, root);
    }
    private bool JumpToDir(string dir, MyNode node)
    {
        if (!node.name.Equals(dir))
        {
            foreach (var child in node.children.Values)
            {
                if (child != null)
                {
                    return JumpToDir(dir, child);
                }
            }
        }
        else
        {
            currentWorkingDirectory = node;
            return true;
        }

        return false;
    }
    /*
     * This method is meant for devs, users can't create new dirs
     * You can only add dirs to the current directory
     */
    public void AddChildDir(string name)
    {
        if (name != null)
        {
            currentWorkingDirectory.children.Add(name, new MyNode(currentWorkingDirectory,name)
            {
                parent = currentWorkingDirectory
            });
        }
    }
        
    /*
    * This method is meant for devs, users can't delete new dirs
    * You can only remove children dirs of the current directory
    */
    public void RemoveChildDir(string name)
    {
        if (name != null)
        {
            currentWorkingDirectory.children.Remove(name);
        }
    }
        
    public String getCurrentDir()
    {
        return currentWorkingDirectory.name;
    }

    public String getParent()
    {
        return currentWorkingDirectory.parent.name;
    }
    public bool isChildDir(string dir)
    {
        return currentWorkingDirectory.children.ContainsKey(dir);
    }

    public bool HasParent()
    {
        return currentWorkingDirectory.parent != null;
    }
        
    public bool HasChildren()
    {
        return currentWorkingDirectory.children.Count != 0;
    }

    public void StepInside(string dir)
    {
        currentWorkingDirectory = currentWorkingDirectory.children[dir];
    }

    public void StepBack()
    {
        if (currentWorkingDirectory.parent != null)
        {
            currentWorkingDirectory = currentWorkingDirectory.parent;
        }
    }
    public ICollection<string> getSubdirectories()
    {
        return currentWorkingDirectory.children.Keys;
    }
    public class MyNode
    {
        public readonly string name;
        public MyNode parent;

        public IDictionary<string, MyNode> children;
            
        public MyNode(MyNode parent, string name)
        {
            this.parent = parent;
            this.name = name;
            children = new Dictionary<string, MyNode>();
        }

        override 
            public string ToString()
        {
            return this.name + " ";
        }
    }
}