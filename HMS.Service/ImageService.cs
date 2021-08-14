using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HMS.Service
{

    public interface IImageService
    {
        bool UploadImage(string keyName, IFormFile file);
    }
    public class ImageService : IImageService
    {
        AWS _aws;
        public ImageService(AWS aws)
        {
            _aws = aws;
        }

        public bool UploadImage(string keyName, IFormFile file)
        {
            string bucketName = "hmsdocuments";
            //string keyName = "yunus/Capture001.png";
            //string filePath = @"C:\Users\jfaroom2\Pictures\Feedback\images\Capture001.png";
            //var client = new AmazonS3Client("AKIAR26TYWGAQJQV5OPO", "ppnmsgC5vYEWPRFIpHgK43h2wuMfu2hGfPRygrbv", Amazon.RegionEndpoint.USEast2);
            var client = new AmazonS3Client(_aws.AccessId, _aws.AccessKey, Amazon.RegionEndpoint.USEast2);
            using (var newMemoryStream = new MemoryStream())
            {
                file.CopyTo(newMemoryStream);
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    InputStream = newMemoryStream,
                    CannedACL = S3CannedACL.PublicRead
                };
                PutObjectResponse response = client.PutObjectAsync(putRequest).Result;
                return response.HttpStatusCode.ToString() == "200" ? true : false;
            }
        }
    }
}
