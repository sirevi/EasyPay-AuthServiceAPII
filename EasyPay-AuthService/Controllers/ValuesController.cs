using Microsoft.AspNetCore.Mvc;

namespace EasyPay_AuthService.Controllers
{
    public class ValuesController : BaseController
    {
        private static List<string> Values = new List<string>
        {
            "value1", "value2", "value3", "value4", "value5", "value6"
        };

        public ValuesController(ILogger<ValuesController> logger)
            : base(logger)
        {
        }


        [HttpGet("getdata")]
        public IEnumerable<string> GetValues()
        {
            return Values;
        }

        [HttpGet("getdata-by-number")]
        public string GetValueByNumber(int number)
        {
            string getvalue = "value" + number;
            string respval = Values.Where(x => x == getvalue).FirstOrDefault();
            return respval;
        }

        [HttpPost("addvalue")]
        public string AddValue(int number)
        {
            string value = "value" + number;
            string getpval = Values.Where(x => x == value).FirstOrDefault();
            if (!string.IsNullOrEmpty(getpval) )
                return $"{getpval} already exist !";

            Values.Add(value);
            return $"Successfully added {value}.";
        }
    }
}
