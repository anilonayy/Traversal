using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers.Abstracts
{
    public interface IFileOperationsAbstract
    {
        public bool DeleteFile(string path);
    }
}
