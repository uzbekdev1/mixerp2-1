// ReSharper disable All
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using MixERP.Net.DbFactory;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using Npgsql;
using PetaPoco;
using Serilog;

namespace MixERP.Net.Schemas.Core.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "core.tax_base_amount_types".
    /// </summary>
    public class TaxBaseAmountType : DbAccess, ITaxBaseAmountTypeRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "core".
        /// </summary>
        public override string _ObjectNamespace => "core";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "tax_base_amount_types".
        /// </summary>
        public override string _ObjectName => "tax_base_amount_types";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
        public long _LoginId { get; set; }

        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Performs SQL count on the table "core.tax_base_amount_types".
        /// </summary>
        /// <returns>Returns the number of rows of the table "core.tax_base_amount_types".</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Count()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM core.tax_base_amount_types;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.tax_base_amount_types" to return all instances of the "TaxBaseAmountType" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> GetAll()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.tax_base_amount_types ORDER BY tax_base_amount_type_code;";
            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.tax_base_amount_types" to return all instances of the "TaxBaseAmountType" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<dynamic> Export()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.tax_base_amount_types ORDER BY tax_base_amount_type_code;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.tax_base_amount_types" with a where filter on the column "tax_base_amount_type_code" to return a single instance of the "TaxBaseAmountType" class. 
        /// </summary>
        /// <param name="taxBaseAmountTypeCode">The column "tax_base_amount_type_code" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "TaxBaseAmountType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public MixERP.Net.Entities.Core.TaxBaseAmountType Get(string taxBaseAmountTypeCode)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"TaxBaseAmountType\" filtered by \"TaxBaseAmountTypeCode\" with value {TaxBaseAmountTypeCode} was denied to the user with Login ID {_LoginId}", taxBaseAmountTypeCode, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.tax_base_amount_types WHERE tax_base_amount_type_code=@0;";
            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql, taxBaseAmountTypeCode).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "core.tax_base_amount_types" with a where filter on the column "tax_base_amount_type_code" to return a multiple instances of the "TaxBaseAmountType" class. 
        /// </summary>
        /// <param name="taxBaseAmountTypeCodes">Array of column "tax_base_amount_type_code" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "TaxBaseAmountType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> Get(string[] taxBaseAmountTypeCodes)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. taxBaseAmountTypeCodes: {taxBaseAmountTypeCodes}.", this._LoginId, taxBaseAmountTypeCodes);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.tax_base_amount_types WHERE tax_base_amount_type_code IN (@0);";

            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql, taxBaseAmountTypeCodes);
        }

        /// <summary>
        /// Custom fields are user defined form elements for core.tax_base_amount_types.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table core.tax_base_amount_types</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get custom fields for entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='core.tax_base_amount_types' ORDER BY field_order;";
                return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('core.tax_base_amount_types'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of core.tax_base_amount_types.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table core.tax_base_amount_types</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            List<DisplayField> displayFields = new List<DisplayField>();

            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return displayFields;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT tax_base_amount_type_code AS key, tax_base_amount_type_code || ' (' || tax_base_amount_type_name || ')' as value FROM core.tax_base_amount_types;";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                using (DataTable table = DbOperation.GetDataTable(this._Catalog, command))
                {
                    if (table?.Rows == null || table.Rows.Count == 0)
                    {
                        return displayFields;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        if (row != null)
                        {
                            DisplayField displayField = new DisplayField
                            {
                                Key = row["key"].ToString(),
                                Value = row["value"].ToString()
                            };

                            displayFields.Add(displayField);
                        }
                    }
                }
            }

            return displayFields;
        }

        /// <summary>
        /// Inserts or updates the instance of TaxBaseAmountType class on the database table "core.tax_base_amount_types".
        /// </summary>
        /// <param name="taxBaseAmountType">The instance of "TaxBaseAmountType" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic taxBaseAmountType, List<EntityParser.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }



            object primaryKeyValue = taxBaseAmountType.tax_base_amount_type_code;

            if (!string.IsNullOrWhiteSpace(taxBaseAmountType.tax_base_amount_type_code))
            {
                primaryKeyValue = taxBaseAmountType.tax_base_amount_type_code;
                this.Update(taxBaseAmountType, taxBaseAmountType.tax_base_amount_type_code);
            }
            else
            {
                primaryKeyValue = this.Add(taxBaseAmountType);
            }

            string sql = "DELETE FROM core.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM core.custom_field_setup " +
                         "WHERE form_name=core.get_custom_field_form_name('core.tax_base_amount_types')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO core.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT core.get_custom_field_setup_id_by_table_name('core.tax_base_amount_types', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of TaxBaseAmountType class on the database table "core.tax_base_amount_types".
        /// </summary>
        /// <param name="taxBaseAmountType">The instance of "TaxBaseAmountType" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic taxBaseAmountType)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. {TaxBaseAmountType}", this._LoginId, taxBaseAmountType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, taxBaseAmountType, "core.tax_base_amount_types", "tax_base_amount_type_code");
        }

        /// <summary>
        /// Inserts or updates multiple instances of TaxBaseAmountType class on the database table "core.tax_base_amount_types";
        /// </summary>
        /// <param name="taxBaseAmountTypes">List of "TaxBaseAmountType" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> taxBaseAmountTypes)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. {taxBaseAmountTypes}", this._LoginId, taxBaseAmountTypes);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            var result = new List<object>();
            int line = 0;
            try
            {
                using (Database db = new Database(Factory.GetConnectionString(this._Catalog), Factory.ProviderName))
                {
                    using (Transaction transaction = db.GetTransaction())
                    {
                        foreach (dynamic taxBaseAmountType in taxBaseAmountTypes)
                        {
                            line++;



                            object primaryKeyValue = taxBaseAmountType.tax_base_amount_type_code;

                            if (!string.IsNullOrWhiteSpace(taxBaseAmountType.tax_base_amount_type_code))
                            {
                                result.Add(taxBaseAmountType.tax_base_amount_type_code);
                                db.Update("core.tax_base_amount_types", "tax_base_amount_type_code", taxBaseAmountType, taxBaseAmountType.tax_base_amount_type_code);
                            }
                            else
                            {
                                result.Add(db.Insert("core.tax_base_amount_types", "tax_base_amount_type_code", taxBaseAmountType));
                            }
                        }

                        transaction.Complete();
                    }

                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                string errorMessage = $"Error on line {line} ";

                if (ex.Code.StartsWith("P"))
                {
                    errorMessage += Factory.GetDBErrorResource(ex);

                    throw new MixERPException(errorMessage, ex);
                }

                errorMessage += ex.Message;
                throw new MixERPException(errorMessage, ex);
            }
            catch (System.Exception ex)
            {
                string errorMessage = $"Error on line {line} ";
                throw new MixERPException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Updates the row of the table "core.tax_base_amount_types" with an instance of "TaxBaseAmountType" class against the primary key value.
        /// </summary>
        /// <param name="taxBaseAmountType">The instance of "TaxBaseAmountType" class to update.</param>
        /// <param name="taxBaseAmountTypeCode">The value of the column "tax_base_amount_type_code" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic taxBaseAmountType, string taxBaseAmountTypeCode)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"TaxBaseAmountType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {TaxBaseAmountType}", taxBaseAmountTypeCode, this._LoginId, taxBaseAmountType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, taxBaseAmountType, taxBaseAmountTypeCode, "core.tax_base_amount_types", "tax_base_amount_type_code");
        }

        /// <summary>
        /// Deletes the row of the table "core.tax_base_amount_types" against the primary key value.
        /// </summary>
        /// <param name="taxBaseAmountTypeCode">The value of the column "tax_base_amount_type_code" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(string taxBaseAmountTypeCode)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"TaxBaseAmountType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", taxBaseAmountTypeCode, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM core.tax_base_amount_types WHERE tax_base_amount_type_code=@0;";
            Factory.NonQuery(this._Catalog, sql, taxBaseAmountTypeCode);
        }

        /// <summary>
        /// Performs a select statement on table "core.tax_base_amount_types" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> GetPaginatedResult()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.tax_base_amount_types ORDER BY tax_base_amount_type_code LIMIT 10 OFFSET 0;";
            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "core.tax_base_amount_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> GetPaginatedResult(long pageNumber)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM core.tax_base_amount_types ORDER BY tax_base_amount_type_code LIMIT 10 OFFSET @0;";

            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql, offset);
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM core.filters WHERE object_name='core.tax_base_amount_types' AND lower(filter_name)=lower(@0);";
            return Factory.Get<EntityParser.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "core.tax_base_amount_types".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "TaxBaseAmountType" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountWhere(List<EntityParser.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.tax_base_amount_types WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.TaxBaseAmountType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.tax_base_amount_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.tax_base_amount_types WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.TaxBaseAmountType(), filters);

            sql.OrderBy("tax_base_amount_type_code");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "core.tax_base_amount_types".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "TaxBaseAmountType" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountFiltered(string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.tax_base_amount_types WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.TaxBaseAmountType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.tax_base_amount_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "TaxBaseAmountType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.TaxBaseAmountType> GetFiltered(long pageNumber, string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"TaxBaseAmountType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.tax_base_amount_types WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.TaxBaseAmountType(), filters);

            sql.OrderBy("tax_base_amount_type_code");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.TaxBaseAmountType>(this._Catalog, sql);
        }


    }
}