// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http;
using MixERP.Net.Schemas.Office.Data;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using CustomField = PetaPoco.CustomField;

namespace MixERP.Net.Api.Office.Fakes
{
    public class WorkCenterRepository : IWorkCenterRepository
    {
        public long Count()
        {
            return 1;
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> GetAll()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public IEnumerable<dynamic> Export()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public MixERP.Net.Entities.Office.WorkCenter Get(int workCenterId)
        {
            return new MixERP.Net.Entities.Office.WorkCenter();
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> Get([FromUri] int[] workCenterIds)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> GetPaginatedResult()
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> GetPaginatedResult(long pageNumber)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public long CountWhere(List<EntityParser.Filter> filters)
        {
            return 1;
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public long CountFiltered(string filterName)
        {
            return 1;
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            return Enumerable.Repeat(new EntityParser.Filter(), 1).ToList();
        }

        public IEnumerable<MixERP.Net.Entities.Office.WorkCenter> GetFiltered(long pageNumber, string filterName)
        {
            return Enumerable.Repeat(new MixERP.Net.Entities.Office.WorkCenter(), 1);
        }

        public IEnumerable<DisplayField> GetDisplayFields()
        {
            return Enumerable.Repeat(new DisplayField(), 1);
        }

        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            return Enumerable.Repeat(new CustomField(), 1);
        }

        public object AddOrEdit(dynamic workCenter, List<EntityParser.CustomField> customFields)
        {
            return true;
        }

        public void Update(dynamic workCenter, int workCenterId)
        {
            if (workCenterId > 0)
            {
                return;
            }

            throw new ArgumentException("workCenterId is null.");
        }

        public object Add(dynamic workCenter)
        {
            return true;
        }

        public List<object> BulkImport(List<ExpandoObject> workCenters)
        {
            return Enumerable.Repeat(new object(), 1).ToList();
        }

        public void Delete(int workCenterId)
        {
            if (workCenterId > 0)
            {
                return;
            }

            throw new ArgumentException("workCenterId is null.");
        }


    }
}