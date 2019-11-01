namespace AService.Controllers {
    using System.Threading.Tasks;
    using Core;
    using Dapr;
    using Microsoft.AspNetCore.Mvc;
 /// <summary>
    /// Sample showing Dapr integration with controller.
    /// </summary>
    [ApiController]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Gets the account information as specified by the id.
        /// </summary>
        /// <param name="account">Account information for the id from Dapr state store.</param>
        /// <returns>Account information.</returns>
        [HttpGet("{account}")]
        public ActionResult<Account> Get(StateEntry<Account> account)
        {
            if (account.Value is null)
            {
                return this.NotFound();
            }

            return account.Value;
        }

       
    }
   
    
}