using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
 
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ISession session = bindingContext.ActionContext.HttpContext.Session;
            if(bindingContext == null) {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            CartView cart = null;
            if (session != null)
            {
                cart = session.GetString("Cart") != null ? JsonConvert.DeserializeObject<CartView>(session.GetString("Cart")) : null;
            }
            if (cart == null) {
               cart = new CartView();
                if(session != null) {
                    session.SetString(sessionKey, JsonConvert.SerializeObject(cart));
                }
            }
            //bindingContext.ModelState.SetModelValue(sessionKey,  cart);
            bindingContext.Result = ModelBindingResult.Success(cart);
            return Task.CompletedTask;
        }
    }
}
