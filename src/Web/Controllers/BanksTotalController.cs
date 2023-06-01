using Domain.Interfaces.Wrappers;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Web.Controllers.Abstract;

namespace Web.Controllers
{
    public class BanksTotalController : BaseController
    {
        private readonly IBanksTotalWrapper<Guid, BanksTotalViewModel> _banksTotalWrapper;

        public BanksTotalController(
            IBanksTotalWrapper<Guid, BanksTotalViewModel> banksTotalWrapper)
        {
            _banksTotalWrapper = banksTotalWrapper
                ?? throw new ArgumentNullException(nameof(banksTotalWrapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return TryBlock(() => View());
        }

        public IActionResult GetCreateView()
        {
            return TryBlock(() =>
            {
                var banksTotals = _banksTotalWrapper.ReadAll();
                return View("CreateView", banksTotals);
            });
        }

        [HttpPost]
        public IActionResult Create(BanksTotalViewModel viewModel)
        {
            return TryBlock(() =>
            {
                if (viewModel.Id != Guid.Empty)
                {
                    _banksTotalWrapper.Create(viewModel);
                }

                return Read();
                //Json(viewModel.Total);
            });
        }

        [HttpGet]
        public IActionResult Read()
        {
            return TryBlock(() =>
            {
            var banksTotals = _banksTotalWrapper.ReadAll();
            var jsonResult = ConvertToJson(banksTotals);

            Response.ContentType = "text/html;charset=utf-8";
            return View("BanksTotal", jsonResult);
            });
        }
        public IActionResult GetUpdateView()
        {
            return TryBlock(() =>
            {
                var banksTotals = _banksTotalWrapper.ReadAll();
                return View("UpdateView", banksTotals);
            });
        }

        public IActionResult Update(Guid id, decimal total)
        {
            return TryBlock(() =>
            {
                _banksTotalWrapper.Update(id, total);

                return Read();
            });
        }

        public IActionResult GetDeleteView()
        {
            return TryBlock(() =>
            {
                var banksTotals = _banksTotalWrapper.ReadAll();
                return View("DeleteView", banksTotals);
            });
        }

        public IActionResult Delete(Guid id)
        {
            return TryBlock(() =>
            {
                _banksTotalWrapper.Delete(id);

                return Read();
            });
        }

        private string ConvertToJson(IEnumerable<BanksTotalViewModel> banksTotals) =>
            JsonSerializer.Serialize(
                banksTotals.Select(bankTotal => new
                {
                    Bank = bankTotal.BankModel.Name,
                    Money = bankTotal.Total,
                }),
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                });
    }
}
