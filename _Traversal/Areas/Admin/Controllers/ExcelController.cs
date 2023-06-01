using _Traversal.Models;
using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace _Traversal.Areas.Admin.Controllers
{
    public class ExcelController : BaseController


    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> data = new List<DestinationModel>();

            using (var c = new Context())
            {
                data = c.Destinatons.Select(x => new DestinationModel
                {
                    City = x.City,
                    Capacity = x.Capacity,
                    DayNight = x.DayNight,
                    DestinationId = x.DestinationId,
                    Price = x.Price
                }).ToList();
            }
            return data;

        }
        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList<DestinationModel>(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;


                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;

                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yenidosya.xlsx");
                }
            }


        }
    }
}
