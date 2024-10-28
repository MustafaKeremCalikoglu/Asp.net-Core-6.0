using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TravelCore.Areas.Admin.Models;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Excel")]
    [Authorize(Roles = "admin")]

    public class ExcelController : Controller
    {   
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("ExcelEkleStatic")]

        public IActionResult ExcelEkleStatic()
        {

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats" +
                "-officedocument.spreadsheetml.sheet", "Rotalarımız.xlsx");
        
        }
        [Route("DestinationList")]

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c=new Context())
            {
                var result = c.Destinations.ToList();
                foreach (var item in result)
                {
                    var destinate = new DestinationModel();
                    destinate.city = item.City;
                    destinate.Capacity = item.Capacity;
                    destinate.Price = item.Price;
                    destinate.Daynight = item.DayNight;
                    destinationModels.Add(destinate);

                }

                //destinationModels=c.Destinations.Select(x=>new DestinationModel
                //{
                //    city=x.City,
                //    Daynight=x.DayNight,
                //    Price=x.Price,
                //    Capacity=x.Capacity
                //}).ToList();

            }
            return destinationModels;
        }
        [Route("DestinationExcelRaportDynamic")]

        public IActionResult DestinationExcelRaportDynamic()
        {
            using (var workbook=new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Sdüresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.city;
                    workSheet.Cell(rowCount, 2).Value = item.Daynight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.opensxmformat-officedocument.spreadsheetml.sheet", "yeni1.xlsx");

                }


            }

        }

    }
}
