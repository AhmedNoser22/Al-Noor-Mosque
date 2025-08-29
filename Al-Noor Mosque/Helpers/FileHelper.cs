namespace Al_Noor_Mosque.Helpers
{
    public class FileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _PathImage;

        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _PathImage =$"{_webHostEnvironment.WebRootPath}{FileSetting.IMAGE_PATH}";
        }
        public async Task<string> SaveImages<T>(T ob) where T : class, IHelperService
        {
            if (ob.image == null || ob.image.Length == 0)
                return string.Empty;

            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(ob.image.FileName)}";
            var path = Path.Combine(_PathImage, imageName);

            using var stream = File.Create(path);
            await ob.image.CopyToAsync(stream);

            return $"{FileSetting.IMAGE_PATH}/{imageName}";
        }

        public void DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;

            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

    }
}
