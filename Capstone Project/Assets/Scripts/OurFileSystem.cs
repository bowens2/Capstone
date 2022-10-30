using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* File System class using a tree like data structure to allow the user to navigate a file structure
*/
public class OurFileSystem
{
    private MyNode root;
    private MyNode currentWorkingDirectory { get; set; }
        
    /*
    * The Directory tree starts with root dir that will automatically be the root dir
    */
    public OurFileSystem(string rootName)
    {
        Console.WriteLine("Constructor start");
        root = new MyNode(null, rootName);
        currentWorkingDirectory = root;
        Console.WriteLine("Constructor success");
    }
        
    public void GotToRoot()
    {
        currentWorkingDirectory = root;
    }
    /*
     * This method is meant for devs, users can't create new dirs
     * You can only add dirs to the current directory
     */
    public void AddChildDir(string name)
    {
        Console.WriteLine("addDir started\n");
        if (name != null)
        {
            var newNode = new MyNode(currentWorkingDirectory, name);
            // Console.WriteLine("currDir = " + currentWorkingDirectory);
            // Console.WriteLine("currDir.children = " + currentWorkingDirectory.children);
            // Console.WriteLine("name = " + name);
            // Console.WriteLine("newNode = " + newNode);
            currentWorkingDirectory.children.Add(name, new MyNode(currentWorkingDirectory,name));
        }
        else
        {
            // Console.WriteLine("non null names\n");
        }
        Console.WriteLine("addDir done");
    }
        
    /*
    * This method is meant for devs, users can't delete new dirs
    * You can only remove children dirs of the current directory
    */
    public void RemoveChildDir(string name)
    {
        Console.WriteLine("removeChildDir started");
        if (name != null)
        {
            currentWorkingDirectory.children.Remove(name);
        }
        else
        {
            Console.WriteLine("non null names");
        }
        Console.WriteLine("removeChildDir done");
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
        currentWorkingDirectory = currentWorkingDirectory.parent;
    }
    public ICollection<string> getSubdirectories()
    {
        return currentWorkingDirectory.children.Keys;
    }
    public class MyNode
    {
        public string name;
        public MyNode parent;

        public IDictionary<string, MyNode> children;
            
        public MyNode(MyNode parent, string name)
        {
            this.parent = parent;
            this.name = name;
            this.children = new Dictionary<string, MyNode>();
        }
        //debug
        override 
            public String ToString()
        {
            return this.name + " ";
        }
    }
        
    // public static void Main(string [] args)
    // {
    //     try
    //     {
    //         Console.WriteLine("hello");
    //
    //         var dir = new OurDirectoryTree("root");
    //         dir.AddChildDir("docs");
    //         dir.AddChildDir("downloads");                
    //         
    //         // Console.WriteLine(" ls = \n" + dir.Ls() + " ls test done\n");
    //
    //         Console.WriteLine(dir.StepIn("docs") + "\n");
    //         dir.AddChildDir("images");
    //         dir.AddChildDir("others");
    //         
    //         Console.WriteLine(" ls = \n" + dir.Ls() + " ls test done\n");
    //
    //         Console.ReadLine();
    //         Console.ReadKey();
    //         Environment.Exit(0);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("Crash! = " + e );
    //         Console.ReadKey();
    //         throw;
    //     }
    //     
    // }
}