using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;
using XOProject.Services.Domain;

namespace XOProject.Services.Exchange
{
    public class AnalyticsService : GenericService<HourlyShareRate>,IAnalyticsService
    {  
        public AnalyticsService(IShareRepository shareRepository) : base(shareRepository)
        {
        }

        public async Task<AnalyticsPrice> GetDailyAsync(string symbol, int year,int month,int day)
        {
            var summary = await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol) && x.TimeStamp.Year == year && x.TimeStamp.Month==month && x.TimeStamp.Day==day) 
                .OrderBy(x => x.TimeStamp).ToListAsync();

            decimal maxRate = summary.Max(x => x.Rate);
            decimal minRate = summary.Min(x => x.Rate);

            decimal openRate = summary.FirstOrDefault().Rate;
            decimal closingRate = summary.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;

            var monthlySummary = new AnalyticsPrice { Open = openRate, Close = closingRate, High = maxRate, Low = minRate };

            return monthlySummary;
        }

        public async Task<AnalyticsPrice> GetWeeklyAsync(string symbol, int year, int week)
        {
            var summary = await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol) && x.TimeStamp.Year == year && x.TimeStamp.Month == week)
                .OrderBy(x => x.TimeStamp).ToListAsync();

            decimal maxRate = summary.Max(x => x.Rate);
            decimal minRate = summary.Min(x => x.Rate);

            decimal openRate = summary.FirstOrDefault().Rate;
            decimal closingRate = summary.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;

            var monthlySummary = new AnalyticsPrice { Open = openRate, Close = closingRate, High = maxRate, Low = minRate };

            return monthlySummary;
        }

        public async Task<AnalyticsPrice> GetMonthlyAsync(string symbol, int year, int month)
        {
            var summary = await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol) && x.TimeStamp.Year == year && x.TimeStamp.Month == month)
                .OrderBy(x => x.TimeStamp).ToListAsync();

            decimal maxRate = summary.Max(x => x.Rate);
            decimal minRate = summary.Min(x => x.Rate);

            decimal openRate = summary.FirstOrDefault().Rate;
            decimal closingRate = summary.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;

            var monthlySummary = new AnalyticsPrice{Open = openRate, Close = closingRate, High = maxRate, Low = minRate};

            return monthlySummary;


        }
    }
}