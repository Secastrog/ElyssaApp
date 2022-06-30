using System;
using BackElyssa.Models;
using BackElyssa.Class;
using System.Net;
using Newtonsoft.Json;

namespace BackElyssa.Class.ElyssaAccount
{
    public class ElyssaAccount
    {
        private readonly ElyssaAppBDContext _context;
        public ElyssaAccount()
        {
            _context = new ElyssaAppBDContext();
        }

        public ResponseParameters CreateAccountElyssa(Dto.Insert objInsert)
        {
            //se genera objeto para controlar respuestas
            ResponseParameters ObjResponse = new ResponseParameters();
            try
            {
                //Se inicia proceso de creacion de cuenta
                var Insert = new Models.ElyssaAccount()
                {
                    Name = objInsert.Name,
                    SurName = objInsert.SurName,
                    Email = objInsert.Email,
                    Password = objInsert.Password,
                };

                _context.ElyssaAccounts.Add(Insert);
                _context.SaveChanges();
                if(Insert.IdAcElyssa > 0)
                {
                    return ObjResponse.SelectDescription(1, Convert.ToInt32(Insert.IdAcElyssa));
                }
                else
                {
                    //No se logro crear cuenta
                    return ObjResponse.SelectDescription(90);
                }
            }
            catch (Exception ex)
            {
                //Ha ocurrido un error inesperado 
                return ObjResponse.SelectDescription(90);
            }
        }

        public ResponseParameters Login (Dto.login ObjLogin)
        {
            ResponseParameters Objresponse = new ResponseParameters();
            try
            {
                //Se va a validar si el usuario existe
                var userExist = _context.ElyssaAccounts.Where(x => x.Email == ObjLogin.User).First();
                //Se crea objeto para relacionar parametros
                Dto.GetData ObjGetData = new Dto.GetData();
                if(userExist.Email == ObjLogin.User)
                {
                    //se valida contraseña
                    if(userExist.Password == ObjLogin.Password)
                    {
                        //El usuario concuerda con los datos ingresado, puede continuar
                        return Objresponse.SelectDescription(1, Convert.ToInt32(userExist.IdAcElyssa));
                    }
                    else
                    {
                        return Objresponse.SelectDescription(3);

                    }
                }
                else
                {
                    return Objresponse.SelectDescription(2);
                }
            }
            catch (Exception ex)
            {
                return Objresponse.SelectDescription(2);
            }
        }

        public Dto.ResponseClima GetClima(string Ciudad)
        {
            Dto.ResponseClima objresponse = new Dto.ResponseClima();
            try
            {
                //Se realizara consumo de api de clima
                var url = $"https://api.openweathermap.org/data/2.5/weather?q=" + Ciudad + "&appid=4d8fb5b93d4af21d66a2948710284366&units=standard";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return objresponse;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string ObjBody = objReader.ReadToEnd();
                                Dto.ResponseClima ObjResponses = JsonConvert.DeserializeObject<Dto.ResponseClima>(ObjBody);

                                Console.WriteLine(ObjBody);
                                return ObjResponses;

                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    //Error al consumir api de clima 
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Ocurrio error
                return null;
            }
        }

    }
}
namespace BackElyssa.Class.ElyssaAccount.Dto
{
    public class GetData
    {
        public int IdAcElyssa { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
    public class Insert
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
    public class login
    {
        public string? Password { get; set; }
        public string? User { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
    public class ResponseClima
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }
}
