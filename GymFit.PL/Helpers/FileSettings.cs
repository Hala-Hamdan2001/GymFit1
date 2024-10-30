namespace GymFit.PL.Helpers
{
    public class FileSettings
    {
        public static string UploadFile(IFormFile file,string folderName) {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);
            var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            fileStream.Close();
            return fileName;
        }
        public static void DeleteFile(string fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
