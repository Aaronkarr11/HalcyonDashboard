﻿using HalcyonCore.SharedEntities;

namespace HalcyonDashboard.Services
{
    public interface ITransactionService
    {
        DashBoard DashBoardData { get; set; }

        Task<DashBoard> GetWorkTaskPercentages();
    }
}