// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using PetaPoco;

namespace MixERP.Net.Schemas.Core.Data
{
    public interface ITaxAuthorityRepository
    {
        /// <summary>
        /// Counts the number of TaxAuthority in ITaxAuthorityRepository.
        /// </summary>
        /// <returns>Returns the count of ITaxAuthorityRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of TaxAuthority. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of TaxAuthority.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> GetAll();

        /// <summary>
        /// Returns all instances of TaxAuthority to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of TaxAuthority.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the TaxAuthority against taxAuthorityId. 
        /// </summary>
        /// <param name="taxAuthorityId">The column "tax_authority_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of TaxAuthority.</returns>
        MixERP.Net.Entities.Core.TaxAuthority Get(int taxAuthorityId);

        /// <summary>
        /// Returns multiple instances of the TaxAuthority against taxAuthorityIds. 
        /// </summary>
        /// <param name="taxAuthorityIds">Array of column "tax_authority_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of TaxAuthority.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> Get(int[] taxAuthorityIds);

        /// <summary>
        /// Custom fields are user defined form elements for ITaxAuthorityRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for TaxAuthority.</returns>
        IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding TaxAuthority.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for TaxAuthority.</returns>
        IEnumerable<DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of TaxAuthority class to ITaxAuthorityRepository.
        /// </summary>
        /// <param name="taxAuthority">The instance of TaxAuthority class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic taxAuthority, List<EntityParser.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of TaxAuthority class to ITaxAuthorityRepository.
        /// </summary>
        /// <param name="taxAuthority">The instance of TaxAuthority class to insert.</param>
        object Add(dynamic taxAuthority);

        /// <summary>
        /// Inserts or updates multiple instances of TaxAuthority class to ITaxAuthorityRepository.;
        /// </summary>
        /// <param name="taxAuthorities">List of TaxAuthority class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> taxAuthorities);


        /// <summary>
        /// Updates ITaxAuthorityRepository with an instance of TaxAuthority class against the primary key value.
        /// </summary>
        /// <param name="taxAuthority">The instance of TaxAuthority class to update.</param>
        /// <param name="taxAuthorityId">The value of the column "tax_authority_id" which will be updated.</param>
        void Update(dynamic taxAuthority, int taxAuthorityId);

        /// <summary>
        /// Deletes TaxAuthority from  ITaxAuthorityRepository against the primary key value.
        /// </summary>
        /// <param name="taxAuthorityId">The value of the column "tax_authority_id" which will be deleted.</param>
        void Delete(int taxAuthorityId);

        /// <summary>
        /// Produces a paginated result of 10 TaxAuthority classes.
        /// </summary>
        /// <returns>Returns the first page of collection of TaxAuthority class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 TaxAuthority classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of TaxAuthority class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> GetPaginatedResult(long pageNumber);

        List<EntityParser.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ITaxAuthorityRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of TaxAuthority class using the filter.</returns>
        long CountWhere(List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against ITaxAuthorityRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of TaxAuthority class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> GetWhere(long pageNumber, List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ITaxAuthorityRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of TaxAuthority class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of ITaxAuthorityRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of TaxAuthority class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.TaxAuthority> GetFiltered(long pageNumber, string filterName);



    }
}