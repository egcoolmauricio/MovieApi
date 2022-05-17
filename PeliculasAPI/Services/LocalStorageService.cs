using PeliculasCore.Services;

namespace PeliculasAPI.Services
{
    public class LocalStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task Delete(string path, string container)
        {
            if(path != null)
            {
                var fileName = Path.GetFileName(path);
                var directory = Path.Combine(env.WebRootPath, container, fileName);
                if (File.Exists(directory))
                {
                    File.Delete(directory);
                }
            }
            return Task.FromResult(0);
        }

        public async Task<string> Edit(byte[] data, string extension, string container, string path, string contentType)
        {
            await Delete(path, container);
            return await Save(data, extension, container, contentType);
        }

        public async Task<string> Save(byte[] data, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(env.WebRootPath, container);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var path = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(path, data);
            var actualUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}:" +
                $"//{httpContextAccessor.HttpContext.Request.Host}";
            var dbUrl = Path.Combine(actualUrl, container, fileName)
                .Replace("\\", "/");

            return dbUrl;
        }
    }
}
