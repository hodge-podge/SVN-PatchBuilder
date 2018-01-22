using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace patchBuilder
{
    class FileCrawler
    {
        private string rootPath = "";
        private int fileCnt = 0;
        private Stopwatch sw;
        private List<string> findFiles = new List<string>();
        private List<string> foundFiles = new List<string>();
        string fileExt = "";

        public FileCrawler(string path)
        {
            rootPath = path;
        }

        public List<string> find(List<string> searchList, string fileExtensions = "*.*")
        {
            findFiles = searchList.ConvertAll(x => x.ToLower());
            fileExt = fileExtensions;
            TraverseTreeParallelForEach(@rootPath, (f) => { foundFiles.Add(f); });
            return foundFiles;
        }

        private void TraverseTreeParallelForEach(string root, Action<string> action)
        {
            //Count of files traversed and timer for diagnostic output
            int fileCount = 0;
            sw = Stopwatch.StartNew();

            // Determine whether to parallelize file processing on each folder based on processor count.
            int procCount = System.Environment.ProcessorCount;

            // Data structure to hold names of subfolders to be examined for files.
            Stack<string> dirs = new Stack<string>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = { };
                string[] files = { };

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                // Thrown if we do not have discovery permission on the directory.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Thrown if another process has deleted the directory after we retrieved its name.
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                try
                {
                    files = Directory.GetFiles(currentDir,fileExt);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // Execute in parallel if there are enough files in the directory.
                // Otherwise, execute sequentially.Files are opened and processed
                // synchronously but this could be modified to perform async I/O.
                try
                {
                    if (files.Length < procCount)
                    {
                        foreach (var file in files)
                        {
                            fileCnt++;
                            if (findFiles.Any(file.ToLower().Contains))
                            {
                                action(file);
                            }
                        }
                    }
                    else
                    {
                        Parallel.ForEach(files, () => 0, (file, loopState, localCount) =>
                        {
                            fileCnt++;

                            if (findFiles.Any(file.ToLower().Contains))
                            {
                                action(file);
                            }
                            return localCount;
                        },
                        (c) =>
                        {
                            Interlocked.Add(ref fileCnt, c);
                        });
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Handle((ex) =>
                    {
                        if (ex is UnauthorizedAccessException)
                        {
                            // Here we just output a message and go on.
                            Console.WriteLine(ex.Message);
                            return true;
                        }
                        // Handle other exceptions here if necessary...

                        return false;
                    });
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs) dirs.Push(str);
            }

            // For diagnostic purposes.

            Console.WriteLine("Processed {0} files of {1} in {2} milleseconds", fileCount, fileCnt, sw.ElapsedMilliseconds);
        }
    }
}
