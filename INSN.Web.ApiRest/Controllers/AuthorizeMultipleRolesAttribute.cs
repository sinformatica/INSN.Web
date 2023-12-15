using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace INSN.Web.ApiRest.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeMultipleRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeMultipleRolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
