using Microsoft.AspNetCore.Mvc;
namespace BackElyssa.Controllers
{
    [Route("Api/Models/ElyssaAccount/[controller]")]
    [ApiController]
    public class HistoryClimatesController
    {     
        private Class.HistoryClimate.HistoryClimate _objHistoryClimate;
        public HistoryClimatesController()
        {
            _objHistoryClimate = new Class.HistoryClimate.HistoryClimate();
        }

        [HttpPost("Insert")]
        public Class.ResponseParameters Insert(Class.HistoryClimate.Dto.Insert ObjInsert)
        {
            Class.ResponseParameters objReturn = new Class.ResponseParameters();
            try
            {
                objReturn = _objHistoryClimate.InsertHistory(ObjInsert);
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectDescription(90);
            }
            return objReturn;
        }

        [HttpGet("GetDetail/{id:int}")]
        public Class.HistoryClimate.Dto.GetData GetDetailAcId(int Id)

        {
            Class.HistoryClimate.Dto.GetData ObjReturn = new Class.HistoryClimate.Dto.GetData();
            try 
            { 
                ObjReturn = _objHistoryClimate.GetDetailAcId(Id);
            }
            catch (Exception ex)
            {
                ObjReturn = null;
            }
            return ObjReturn;
        }
    }
}
