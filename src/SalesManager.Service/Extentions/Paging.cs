﻿using Microsoft.EntityFrameworkCore;
using SalesManager.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.Service.Extentions
{
    public static class Paging
    {
        public static async Task<DataCollection<T>> PagedAsync<T>(
                this IQueryable<T> query, int page, int take
            ) where T : class
        {
            var result = new DataCollection<T>
            {
                Total = await query.CountAsync(),
                Page = page
            };
            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(
                        Math.Ceiling(Convert.ToDecimal(result.Total) / take)
                    );
                result.Items = await query.Skip((page - 1) * take)
                                          .Take(take)
                                          .ToListAsync();
            }
            return result;
        }
    }
}
