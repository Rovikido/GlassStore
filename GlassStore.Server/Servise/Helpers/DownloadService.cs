using GlassStore.Server.Domain.Models.Glass;
using GlassStore.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GlassStore.Service.Services
{
    public class DownloadService
    {
        ILogger<DownloadService> _logger;
        private iBaseRepository<Glasses> _data;

        //public DownloadService()
        //{
        //}
        public DownloadService(ILogger<DownloadService> logger, iBaseRepository<Glasses> data) { 
            _logger = logger;
            _data = data;
        }


        public async Task DownloadAllPictToDB()
        {
            string fileWay = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "media", "Glasses");

            byte[] bytes;

            IEnumerable<Glasses> data = (await _data.GetAllAsync());

            int i = 1;
            foreach (var d in data)
            {
                for (int ii = 1; ii < 3; ii++)
                {
                    bytes = System.IO.File.ReadAllBytes($"{fileWay}/{i}/{ii}.png");
                    d.Photos[ii - 1] = Convert.ToBase64String(bytes);

                }
                bytes = System.IO.File.ReadAllBytes($"{fileWay}/{i}/{3}.png");
                d.Photos.Add(Convert.ToBase64String(bytes));

                await _data.UpdateAsync(d.Id, d);
                i++;
            }

            
        }

        public void DownloadPngUrlToMedia(string url)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Media", "png", $"{DateTime.Today.ToString("dd.MM.yyyy")}", "test.jpg");

            Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            var a = Path.GetDirectoryName(fileName);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            };

            _logger.LogInformation($"Pictre was saved in : {fileName}");

        }

        public async Task<byte[]> DownloadJpgAsync(string url)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadDataTaskAsync(url);
            };
        }





    }
}


