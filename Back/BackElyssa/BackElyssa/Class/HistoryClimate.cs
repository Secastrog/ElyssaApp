using System;
using BackElyssa.Models;
using BackElyssa.Class;

namespace BackElyssa.Class.HistoryClimate
{
    public class HistoryClimate
    {
        private readonly ElyssaAppBDContext _context;
        public HistoryClimate()
        {
            _context = new ElyssaAppBDContext();
        }

        public ResponseParameters InsertHistory(Dto.Insert objInsert)
        {
            //se genera objeto para controlar respuestas
            ResponseParameters ObjResponse = new ResponseParameters();
            try
            {
                //Se inicia proceso de creacion de cuenta
                var Insert = new Models.HistoryClimate()
                {
                    City = objInsert.City,
                    Lat = objInsert.Lat,
                    Long = objInsert.Long,
                    Temperature = objInsert.Temperature,
                    IdAcElyssa = objInsert.IdAcElyssa,
                };

                _context.HistoryClimates.Add(Insert);
                _context.SaveChanges();
                if (Insert.IdAcElyssa > 0)
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

        public Dto.GetData GetDetailAcId(int Id)
        {
            try
            {
                var get = _context.HistoryClimates.Where(x => x.IdAcElyssa == Id).First();
                Dto.GetData ObjData = new();
                ObjData.IdClimate = get.IdClimate;
                ObjData.City = get.City;
                ObjData.Lat = get.Lat;
                ObjData.Long = get.Long;
                ObjData.Temperature = get.Temperature;
                ObjData.IdAcElyssa = get.IdAcElyssa;

                return ObjData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
namespace BackElyssa.Class.HistoryClimate.Dto
{
    public class GetData
    {
        public int IdClimate { get; set; }
        public string? City { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? Temperature { get; set; }
        public int? IdAcElyssa { get; set; }
    }
    public class Insert
    {
        public string? City { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? Temperature { get; set; }
        public int? IdAcElyssa { get; set; }
    }
}
