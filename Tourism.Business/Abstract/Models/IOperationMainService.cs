﻿using Tourism.Entities.Models;

namespace Tourism.Business.Abstract.Models
{
    public interface IOperationMainService
    {
        List<OperationMain> GetOperationMain();
        List<OperationMain> GetByDocumentCode(string documentCode);
        //List<OperationMain> GetOperationMainByOperationId(int operationId);
        //OperationMain GetByOperationId(int operationId);
        List<OperationMain> SearchOperationMain(string documentCode, int mainCategoryId, int subCategoryId, DateTime startDate, DateTime endDate, int operatorId, int currencyId, bool isActive);
    }
}
