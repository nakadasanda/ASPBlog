using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myblog1.Controllers
{
    public class ImgController : Controller
    {

        public CloudBlobContainer GetCloudBlobContainer(){
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                    "franprogramer",
                    "16KmMzs663xlhHnwsPQ29u/qDDSiFmU90IAmVePNeG8mwSoqPqHFGeNTPXHgwznUQFhnmFUDoeVhDWPHLI683Q=="),
                true);
            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "mycontainer."
            CloudBlobContainer container = blobClient.GetContainerReference("img");

            return container;
        }

        public IActionResult Postimg(string str)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Postimg(List<IFormFile> files)
        {
            if (files == null) {
                return NotFound();
            }

            CloudBlobContainer container = GetCloudBlobContainer();
            foreach (var formFile in files)
            {
                string contentType = "image/png";
                var filePath = Path.GetTempFileName();
                string fileName = Path.GetFileName(formFile.FileName);
                var stream = new FileStream(filePath, FileMode.Create);
                CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
                blob.Properties.ContentType = contentType;
                blob.UploadFromStreamAsync(stream);
            }
            return View();
        }
    }
}