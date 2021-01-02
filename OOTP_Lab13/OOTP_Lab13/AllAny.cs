
using System;
using System.IO.Compression;

namespace OOTP_Lab13
{
    using System.IO;

    namespace OOTP_Lab13
    {
        public static class DiskInfo
        {
            public static void GetDiskInfo()
            {
                var DiskInfo =  DriveInfo.GetDrives();
                Log.Write("Free space your in hards:");
                foreach (var driveInfo in  DiskInfo)
                {
                    Log.Write($"{driveInfo.Name} - {driveInfo.TotalFreeSpace} bytes");
                }
            } 
        
            public static void GetFileSystem()
            {
                var DiskInfo =  DriveInfo.GetDrives();
                Log.Write("File system:");
                foreach (var driveInfo in  DiskInfo)
                {
                    Log.Write($"{driveInfo.Name} - type format {driveInfo.DriveFormat}");
                }
            }
            public static void GetFileLabel()
            {
                var DiskInfo =  DriveInfo.GetDrives();
                Log.Write("Label disks:");
                foreach (var driveInfo in  DiskInfo)
                {
                    Log.Write($"{driveInfo.Name} - label {driveInfo.VolumeLabel} - total size {driveInfo.TotalSize}");
                }
            }
        }

        public static class FileInfoLocal
        {
            private static string pathFile = "..//..//Log.cs";
            public static void GetPath()
            {
                Log.Write(pathFile);
                FileInfo fileInfo =  new FileInfo(pathFile);
                Log.Write("Full path file: ");
                Log.Write(fileInfo.DirectoryName);
            }

            public static void FullInfo()
            {
                FileInfo fileInfo =  new FileInfo(pathFile);
                Log.Write($"{fileInfo.Name} - {fileInfo.Extension} - {fileInfo.Length}");
                Log.Write($"Data last modified: {fileInfo.CreationTime}");
            }
            
        }

        public static class DirInfoLocal
        {
            private static string pathDir = "..//..//..//OOTP_Lab13";

            public static void CountFiles()
            {
                var dirinfo = new DirectoryInfo(pathDir).GetFiles();
                Log.Write($"Count files {dirinfo.Length}");
            }

            public static void DataCreation()
            {
                var dirinfo = new DirectoryInfo(pathDir);
                Log.Write($"Date creation {dirinfo.CreationTime}");
            }
            public static void CountDir()
            {
                var dirinfo = new DirectoryInfo(pathDir).GetDirectories();
                Log.Write($"Count directories {dirinfo.Length}");
            }
            public static void CountParrentDir()
            {
                var directoryInfo = new DirectoryInfo(pathDir).Parent;
                if (directoryInfo != null)
                {
                    var dirinfo = directoryInfo.GetDirectories();
                    foreach (var dir in dirinfo)
                    {
                        Log.Write($"List parrents dir {dir.Name}");
                    }
                }
            }
            
        }

        public static class FileManager
        {
            private static string path = "D://";
            private static string file = "dirinfo.txt";
            public static void NewRepository(string NameDir)
            {
                StreamWriter outFile = new StreamWriter(path +NameDir+ file, false,System.Text.Encoding.Default);
                DirectoryInfo drive = new DirectoryInfo(path);
                outFile.Write("lab 13 create and modufied file");
                var fileinfo = new FileInfo(path + NameDir + file);
                drive.CreateSubdirectory(NameDir);
                outFile.Close();

                fileinfo.CopyTo(path + NameDir + "copy" + file);
                fileinfo.Delete();
            }

            public static void MoveFilesInPathDir(string path, string expansion, string moveto)
            {
                var drive = new DirectoryInfo(path);
                var files = new DirectoryInfo(path).GetFiles();
                var dir = new DirectoryInfo(path);
                int i = 0;
                foreach (var file in files)
                {
                    if (file.Extension == expansion)
                    {

                        file.CopyTo(moveto + i++ + expansion);
                    }
                }
            }

            public static void DirectoryMove(string path, string moveto)
            {
                var dirinfo = new DirectoryInfo(path);
                dirinfo.MoveTo(moveto);
                
            }
        }

        public static class Zip
        {
        public static void CompressZip(string sourceFile, string compressedFile)
            {
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(compressedFile))
                    {
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream);
                            Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                                sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                        }
                    }
                }
            }
        }
    }
}