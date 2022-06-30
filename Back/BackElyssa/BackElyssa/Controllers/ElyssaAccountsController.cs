using Microsoft.AspNetCore.Mvc;

namespace BackElyssa.Controllers.ElyssaAccount
{
    [Route("Api/Models/ElyssaAccount/[controller]")]
    [ApiController]
    public class ElyssaAccountsController : ControllerBase
    {
        private Class.ElyssaAccount.ElyssaAccount _objElyssaAccount;
        public ElyssaAccountsController()
        {
            _objElyssaAccount = new Class.ElyssaAccount.ElyssaAccount();
        }
        [HttpPost("CreateAccount")]
        public Class.ResponseParameters CreateAccountElyssa(Class.ElyssaAccount.Dto.Insert ObjInsert)
        {
            Class.ResponseParameters objReturn = new Class.ResponseParameters();
            try
            {
                objReturn = _objElyssaAccount.CreateAccountElyssa(ObjInsert);
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectDescription(90);
            }
            return objReturn;
        }

        [HttpPost("Login")]
        public Class.ResponseParameters Login(Class.ElyssaAccount.Dto.login ObjInsert)
        {
            Class.ResponseParameters objReturn = new Class.ResponseParameters();
            try
            {
                objReturn = _objElyssaAccount.Login(ObjInsert);
            }
            catch (Exception ex)
            {
                objReturn = objReturn.SelectDescription(90);
            }
            return objReturn;
        }

        [HttpGet("GetClima/{clima}")]
        public Class.ElyssaAccount.Dto.ResponseClima GetClima(string clima)
        {
            Class.ElyssaAccount.Dto.ResponseClima objReturn = new Class.ElyssaAccount.Dto.ResponseClima();
            try
            {
                objReturn = _objElyssaAccount.GetClima(clima);
            }
            catch (Exception ex)
            {
                return null;
            }
            return objReturn;
        }
    }
}
