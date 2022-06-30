using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace BackElyssa.Class
{
    public class ResponseParameters
    {
        private IConfiguration _Configuration { get; }
        public int Code { get; set; }
        public string Description { get; set; }


        public class Responsecodes
        {
            public Codeee[] Codeees { get; set; }
        }

        public class Codeee
        {
            public int Codee { get; set; }
            public string Description { get; set; }
            public string EmailNotification { get; set; }
            public bool FlagNotification { get; set; }
            public bool FlagInfoAdditional { get; set; }
            public string InfoAdditional { get; set; }

        }


        public long Identity { get; set; }
        public ResponseParameters()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _Configuration = builder.Build();
        }

        public string ToUTF8(string text)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }

        public ResponseParameters SelectDescription(int code, long identity = 0, string Exception = "")
        {
            ResponseParameters objReturn = new();
            try
            {
                var ObjResponseCodes = _Configuration.GetSection("ResponseCodes").Get<Responsecodes>();
                Codeee ObjCodes = ObjResponseCodes.Codeees.First(item => item.Codee == code);
                objReturn.Code = ObjCodes.Codee;
                ObjCodes.Description = ToUTF8(ObjCodes.Description);
                if (objReturn.Code >= 600 && objReturn.Code <= 699)
                {
                    objReturn.Description = $"{objReturn.Code} - No supero validacion reglas de experto - Rechazada";
                }
                else
                {
                    objReturn.Description = $"{objReturn.Code} - {ObjCodes.Description}";
                }
                if (ObjCodes.FlagNotification)
                {

                }
                objReturn.Identity = identity;

            }
            catch (Exception ex)
            {

            }
            return objReturn;
        }

        public static implicit operator Task<object>(ResponseParameters v)
        {
            throw new NotImplementedException();
        }
    }
}