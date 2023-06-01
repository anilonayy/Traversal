using BusinessLayer.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Helpers.Concrete.Uploader
{
    public class FileOperations : IFileOperationsAbstract
    {
       
        public bool DeleteFile(string path)
        {

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
                return false;
        }
    }

}