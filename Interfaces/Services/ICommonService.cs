﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesManager
{
    public interface ICommonService<T, Id>
    {
        Task<List<T>> GetAllAsync();
        Task<BaseResult<T>> GetByIdAsync(Id id);
        Task<BaseResult<T>> CreateAsync(T model);
        Task<BaseResult<T>> CreateMultiple(List<T> listModel);
        Task<BaseResult<T>> UpdateAsync(T model);
        Task<BaseResult<T>> DeleteAsync(Id id);
    }
}
