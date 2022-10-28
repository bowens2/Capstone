using System;
using System.Collections;
using System.Collections.Generic;

// namespace DefaultNamespace
// {
    /*
     * Directory class using a tree like data structure to allow the user to navigate a file structure
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

        public void setToRoot()
        {
            root = currentWorkingDirectory;
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

        /*
         * Cd into a dir
         */
        public string StepIn(string dir)
        {
            Console.WriteLine("Cd into "+dir+" started");
            if (currentWorkingDirectory.children.ContainsKey(dir))
            {
                // Console.WriteLine("child valid");
                // currentWorkingDirectory = currentWorkingDirectory.children[dir];
                // Console.WriteLine("Cd current dir changed to parent");
                var pwd = "pwd = ";
                // Console.WriteLine("child.dir = " + currentWorkingDirectory.children);
                // Console.WriteLine("child.dir.length = " + currentWorkingDirectory.children.Count);
                // Console.WriteLine("writing pwd");
                var truth = currentWorkingDirectory.children.Count > 0;
                // Console.WriteLine("if (currentWorkingDirectory.children.Count > 0) = " );
                // Console.WriteLine(truth.ToString());
                
                if (currentWorkingDirectory.children.Count > 0)
                {
                    foreach (var child in currentWorkingDirectory.children.Keys)
                    {
                        Console.WriteLine("child pwd = " + child);
                        if (child != null)
                        {
                            pwd += child + " >";
                        }
                    }
                }

                Console.WriteLine("exit");
                return pwd;
            }

            return "the same list of dir";
        }
        
        public string StepOut(string back)
        {
            //users cannot step out of the root dir
            if (back.Equals("..") && currentWorkingDirectory != root)
            {
                currentWorkingDirectory = currentWorkingDirectory.parent;
                return "updated list of dir on the left";
            }
            return "the same list of dir";
        }

        public string Ls()
        {
            Console.WriteLine("ls start");
            
            string ls = "Directories\n";

            if (currentWorkingDirectory.children != null)
            {
                Console.WriteLine("currDir = " + currentWorkingDirectory);
                Console.WriteLine("children array = " + currentWorkingDirectory.children);
                Console.WriteLine("children length = " + currentWorkingDirectory.children.Count);

                foreach (var childName in currentWorkingDirectory.children.Keys)
                {
                    if (childName != null)
                    {
                        ls += childName + "\n";
                    }
                }
            }

            ls += "\n";
            
            Console.WriteLine("ls success");
            return ls;
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
// }