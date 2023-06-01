using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Helpers.Uploader
{
    public class FileOperations
    {
        public void DestinationUploader(string fileName, string uploadPath)
        {

        }
        public bool DeleteFile(string path)
        {

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            else
                return false;

            


        }
    }

}