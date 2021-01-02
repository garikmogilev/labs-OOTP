using System;
using System.IO;
using OOTP_Lab13.OOTP_Lab13;

namespace OOTP_Lab13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           Log.WriteInfo();
           DiskInfo.GetDiskInfo();
           DiskInfo.GetFileSystem();
           DiskInfo.GetFileLabel();
           
           FileInfoLocal.GetPath();
           FileInfoLocal.FullInfo();
           
           DirInfoLocal.CountDir();
           DirInfoLocal.CountFiles();
           DirInfoLocal.DataCreation();
           DirInfoLocal.CountParrentDir();
           
           //FileManager.NewRepository(@"Lab 13//");
           //FileManager.MoveFilesInPathDir(@"D:\For training", ".pdf",@"D:\Lab 13\Move\");
           //FileManager.DirectoryMove(@"D:\Ads",@"D:\Lab 13\");
           
           Zip.CompressZip(@"D:\For training\complex.pdf",@"D:\For training\complex.gz");
           Log.CloseFile();
           
           Log.Read();
           Log.CloseFile();
        }
    }
}