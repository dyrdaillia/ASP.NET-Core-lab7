using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace WebApplication7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            // Відображення HTML-форми для вводу даних
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            // Створення текстового файлу з введеними даними
            var filePath = $"{fileName}.txt";
            var fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            // Запис вмісту у файл
            System.IO.File.WriteAllText(filePath, fileContent, Encoding.UTF8);

            // Повернення файлу користувачу для завантаження
            return PhysicalFile(filePath, "text/plain", fileName + ".txt");
        }
    }
}
