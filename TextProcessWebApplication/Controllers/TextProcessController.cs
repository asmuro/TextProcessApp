using Application.Services;
using Domain;
using Domain.Classes;
using Domain.Enums;
using Domain.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace TextProcessWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextProcessController : ControllerBase
    {
        private ITextProcessApplicationService _textProcessApplicationService;        

        [HttpGet(template: "[action]")]
        public IEnumerable<OrderType> GetOrderOptions()
        {
            return _textProcessApplicationService.GetOrderOptions();            
        }

        [HttpGet(template: "[action]")]
        public string GetOrderedText(string textToOrder, OrderType orderOption)
        {
            return _textProcessApplicationService.GetOrderedText(textToOrder, orderOption);
        }

        [HttpGet(template: "[action]")]
        public TextStatistics GetStatistics(string textToAnalyze)
        {            
            return _textProcessApplicationService.GetStatistics(textToAnalyze);
        }

        public TextProcessController(ITextProcessApplicationService textProcessApplicationService)
        {
            this._textProcessApplicationService = textProcessApplicationService;
        }     
    }
}
