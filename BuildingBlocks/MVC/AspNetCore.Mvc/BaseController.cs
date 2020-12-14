using AspNetCore.Common.Identity;
using AspNetCore.Common.Messages;
using AspNetCore.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AspNetCore.Mvc
{
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual string GetCurrentUserId()
        {
            var claim = this.User.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual object GetValueFromToken(string typeName)
        {
            var result = this.User.Claims.ToList().FirstOrDefault(p => p.Type == typeName);
            if (result != null)
            {
                switch (result.ValueType)
                {
                    case ClaimValueTypes.Integer:
                        return int.Parse(result.Value);
                    case ClaimValueTypes.String:
                        return (string)result.Value;
                    case ClaimValueTypes.Boolean:
                        return bool.Parse(result.Value);
                };
            }
            return new Exception("Not enough information. Please login again");
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual T GetCurrentUserId<T>()
        {
            return (T)Convert.ChangeType(GetCurrentUserId(), typeof(T));
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual string GetCurrentUserName()
        {
            return this.User.FindFirst(ClaimTypes.Name).Value;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual List<string> GetCurrentUserRoles()
        {
            return this.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual UserIdentity<T> GetCurrentUserIdentity<T>()
        {
            try
            {
                var oid = GetCurrentUserId<T>();
                if (oid != null)
                {
                    var issuer = new UserIdentity<T>
                    {
                        Id = oid,
                        UserName = GetCurrentUserName(),
                        Roles = GetCurrentUserRoles()
                    };
                    /*issuer.EmployeeInfoModel = (EmployeeInfoModel)JsonConvert.DeserializeObject(
                        Convert.ToString(GetValueFromToken("employeeinfo")), typeof(EmployeeInfoModel));*/
                    issuer.UserModel = (UserModel)JsonConvert.DeserializeObject(
                        Convert.ToString(GetValueFromToken("userInfo")), typeof(UserModel));
                    issuer.MenuPermission =
                        (GrantedPermission)JsonConvert.DeserializeObject(
                            Convert.ToString(GetValueFromToken("permission")), typeof(GrantedPermission));
                    /*issuer.QuotationPermission = (GrantedQuotationPermission)JsonConvert.DeserializeObject(
                        Convert.ToString(GetValueFromToken("quotationPermission")), typeof(GrantedQuotationPermission));*/

                    return issuer;
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual OkObjectResult OkValueObject(object value)
        {
            return Ok(new OkObjectResult(value));
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public new virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        {
            return base.BadRequest(CreateExceptionMessage(modelState));
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual BadRequestObjectResult BadRequest(string message)
        {
            return base.BadRequest(new ExceptionMessage(message));
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public static ExceptionMessage CreateExceptionMessage(ModelStateDictionary modelState)
        {
            var result = new ExceptionMessage();
            result.Details = new List<ExceptionMessage>();

            foreach (var state in modelState)
            {
                var stateError = new ExceptionMessage();
                foreach (var childError in state.Value.Errors)
                {
                    result.Details.Add(new ExceptionMessage
                    {
                        Message = childError.ErrorMessage
                    });
                }
            }

            if (result.Details.Any())
            {
                result.Message = result.Details.First().Message;
            }
            else
            {
                result.Details = null;
            }
            return result;
        }
    }
}