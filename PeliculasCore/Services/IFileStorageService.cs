using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public interface IFileStorageService
    {
        Task<string> Save(byte[] data, string extension, string container, string contentType);

        Task<string> Edit(byte[] data, string extension, string container, string contentType, string path);

        Task Delete(string route, string container);
    }
}
