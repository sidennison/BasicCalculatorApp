using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCalculator;
using BasicCalculatorWeb.Data;
using BasicCalculatorWeb.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCalculatorWeb.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly RequestLogContext _context;

        public CalculatorController(RequestLogContext requestLogContext)
        {
            _context = requestLogContext;
        }

        // GET /calculator
        public async Task<IActionResult> Index()
        {
            return View(await GetCombinedModel(null));
        }

        // POST /calculator/
        [HttpPost]
        public async Task<IActionResult> Index(Calculation calculation)
        {
            // Perform the calculation
            try
            {
                switch (calculation.Operator)
                {
                    case Calculation.Operators.Divide:
                        calculation.Result = Calculator.Calculate(new Divide(), calculation.Value1, calculation.Value2);
                        break;
                    case Calculation.Operators.Multiply:
                        calculation.Result = Calculator.Calculate(new Multiply(), calculation.Value1, calculation.Value2);
                        break;
                    case Calculation.Operators.Add:
                        calculation.Result = Calculator.Calculate(new Add(), calculation.Value1, calculation.Value2);
                        break;
                    case Calculation.Operators.Subtract:
                        calculation.Result = Calculator.Calculate(new Subtract(), calculation.Value1, calculation.Value2);
                        break;
                    default:
                        break;
                }

                calculation.Message = calculation.Result.ToString("G");
            }
            catch (Exception ex)
            {
                calculation.Message = ex.Message;
            }

            // Create a new request log
            RequestLog requestLog = new RequestLog();
            requestLog.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            requestLog.Calculation = String.Format("{0} {1} {2} = {3}", 
                calculation.Value1, Calculation.GetSymbol(calculation.Operator), calculation.Value2, calculation.Message);
            requestLog.RequestDate = DateTime.Now;

            // Save the new log
            _context.Add(requestLog);
            await _context.SaveChangesAsync();
            
            return View(await GetCombinedModel(calculation));
        }

        // Generate return model
        async Task<CombinedModel> GetCombinedModel(Calculation calculation)
        {
            CombinedModel combinedModel = new CombinedModel();
            combinedModel.Calculation = calculation;
            combinedModel.RequestLogs = await _context.RequestLog.OrderByDescending(m => m.Id).Take(RequestLog.Limit).ToListAsync();

            return combinedModel;
        }
    }
}