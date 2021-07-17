using System.IO;

namespace HMS.Domain
{
    public interface IFormFile
    {
        int Length { get; }
        string FileName { get; }

        void CopyTo(FileStream fileStream);
    }
}