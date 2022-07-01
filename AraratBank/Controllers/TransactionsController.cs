using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AraratBank.Models;
using AraratBank.Models.DataBase;
using AraratBank.ViewModels;

namespace AraratBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TransactionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            API api = new API()
            {
                Method=APIMethods.Get,
                URL= "api/Transactions"
            };
            StoreAPI(api);
            await _context.SaveChangesAsync();
            if (_context.Transactions == null)
            {
              return NotFound();
            }
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transactions/5
        // Here you can get more details than in the list
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionViewModel>> GetTransaction(int id)
        {
            API api = new API()
            {
                Method = APIMethods.Get,
                URL = "api/Transactions/{id}"
            };
            StoreAPI(api);
            await _context.SaveChangesAsync();
            if (_context.Transactions == null)
          {
              return NotFound();
          }
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
            var currency = await _context.Currencies.FindAsync(transaction.CurrencyId);

            var viewModel = new TransactionViewModel()
            {
                Date = transaction.Date,
                SoldPrice = transaction.SoldPrice,
                PurchasedPrice = transaction.PurchasedPrice,
                CurrencyType= currency.CurrencyType,
                Status=transaction.Status.ToString()
            };

            return viewModel;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            API api = new API()
            {
                Method = APIMethods.Put,
                URL = "api/Transactions/{id}"
            };
            StoreAPI(api);
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            API api = new API()
            {
                Method = APIMethods.Post,
                URL = "api/Transactions"
            };
            StoreAPI(api);
            if (_context.Transactions == null)
          {
              return Problem("Entity set 'AppDBContext.Transactions'  is null.");
          }
            var currency = await _context.Currencies.FindAsync(transaction.CurrencyId);

            if (currency == null)
            {
                return NotFound("Currency not found");
            }
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            API api = new API()
            {
                Method = APIMethods.Delete,
                URL = "api/Transactions/{id}"
            };
            StoreAPI(api);
            if (_context.Transactions == null)
            {
                return NotFound();
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return (_context.Transactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async void StoreAPI(API api)
        {
            api.Date = DateTime.Now;
            _context.APIs.Add(api);
        }
    }
}
