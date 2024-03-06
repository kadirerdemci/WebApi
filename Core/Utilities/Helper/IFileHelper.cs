using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper
{
    public interface IFileHelper
    {
        string Upload(IFormFile formFile, string root);
        void Delete(string filePath);
        string Update(IFormFile formFile, string filePath, string root);


        

    }
}
