namespace BService.Controllers {
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
        /// Method for depositing to account as psecified in transaction.
        /// </summary>
        /// <param name="transaction">Transaction info.</param>
        /// <param name="stateClient">State client to interact with dapr runtime.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Topic("deposit")]
        [HttpPost("deposit")]
        public async Task<ActionResult<Account>> Deposit(Transaction transaction, [FromServices] StateClient stateClient)
        {
            var state = await stateClient.GetStateEntryAsync<Account>(transaction.Id);
            state.Value ??= new Account() { Id = transaction.Id, };
            state.Value.Balance += transaction.Amount;
            await state.SaveAsync();
            return state.Value;
        }

        /// <summary>
        /// Method for withdrawing from account as specified in transaction.
        /// </summary>
        /// <param name="transaction">Transaction info.</param>
        /// <param name="stateClient">State client to interact with dapr runtime.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Topic("withdraw")]
        [HttpPost("withdraw")]
        public async Task<ActionResult<Account>> Withdraw(Transaction transaction, [FromServices] StateClient stateClient)
        {
            var state = await stateClient.GetStateEntryAsync<Account>(transaction.Id);

            if (state.Value == null)
            {
                return this.NotFound();
            }

            state.Value.Balance -= transaction.Amount;
            await state.SaveAsync();
            return state.Value;
        }
    }
   
    
}