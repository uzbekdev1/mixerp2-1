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
    /// Provides simplified data access features to perform SCRUD operation on the database table "core.shipping_mail_types".
    /// </summary>
    public class ShippingMailType : DbAccess, IShippingMailTypeRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "core".
        /// </summary>
        public override string _ObjectNamespace => "core";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "shipping_mail_types".
        /// </summary>
        public override string _ObjectName => "shipping_mail_types";

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
        /// Performs SQL count on the table "core.shipping_mail_types".
        /// </summary>
        /// <returns>Returns the number of rows of the table "core.shipping_mail_types".</returns>
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
                    Log.Information("Access to count entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM core.shipping_mail_types;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_mail_types" to return all instances of the "ShippingMailType" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "ShippingMailType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> GetAll()
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
                    Log.Information("Access to the export entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_mail_types ORDER BY shipping_mail_type_id;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_mail_types" to return all instances of the "ShippingMailType" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "ShippingMailType" class.</returns>
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
                    Log.Information("Access to the export entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_mail_types ORDER BY shipping_mail_type_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_mail_types" with a where filter on the column "shipping_mail_type_id" to return a single instance of the "ShippingMailType" class. 
        /// </summary>
        /// <param name="shippingMailTypeId">The column "shipping_mail_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "ShippingMailType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public MixERP.Net.Entities.Core.ShippingMailType Get(int shippingMailTypeId)
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
                    Log.Information("Access to the get entity \"ShippingMailType\" filtered by \"ShippingMailTypeId\" with value {ShippingMailTypeId} was denied to the user with Login ID {_LoginId}", shippingMailTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_mail_types WHERE shipping_mail_type_id=@0;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql, shippingMailTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_mail_types" with a where filter on the column "shipping_mail_type_id" to return a multiple instances of the "ShippingMailType" class. 
        /// </summary>
        /// <param name="shippingMailTypeIds">Array of column "shipping_mail_type_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "ShippingMailType" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> Get(int[] shippingMailTypeIds)
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
                    Log.Information("Access to entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. shippingMailTypeIds: {shippingMailTypeIds}.", this._LoginId, shippingMailTypeIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_mail_types WHERE shipping_mail_type_id IN (@0);";

            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql, shippingMailTypeIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for core.shipping_mail_types.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table core.shipping_mail_types</returns>
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
                    Log.Information("Access to get custom fields for entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='core.shipping_mail_types' ORDER BY field_order;";
                return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('core.shipping_mail_types'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of core.shipping_mail_types.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table core.shipping_mail_types</returns>
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
                    Log.Information("Access to get display field for entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT shipping_mail_type_id AS key, shipping_mail_type_code || ' (' || shipping_mail_type_name || ')' as value FROM core.shipping_mail_types;";
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
        /// Inserts or updates the instance of ShippingMailType class on the database table "core.shipping_mail_types".
        /// </summary>
        /// <param name="shippingMailType">The instance of "ShippingMailType" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic shippingMailType, List<EntityParser.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            shippingMailType.audit_user_id = this._UserId;
            shippingMailType.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = shippingMailType.shipping_mail_type_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                primaryKeyValue = shippingMailType.shipping_mail_type_id;
                this.Update(shippingMailType, int.Parse(shippingMailType.shipping_mail_type_id));
            }
            else
            {
                primaryKeyValue = this.Add(shippingMailType);
            }

            string sql = "DELETE FROM core.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM core.custom_field_setup " +
                         "WHERE form_name=core.get_custom_field_form_name('core.shipping_mail_types')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO core.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT core.get_custom_field_setup_id_by_table_name('core.shipping_mail_types', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of ShippingMailType class on the database table "core.shipping_mail_types".
        /// </summary>
        /// <param name="shippingMailType">The instance of "ShippingMailType" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic shippingMailType)
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
                    Log.Information("Access to add entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. {ShippingMailType}", this._LoginId, shippingMailType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, shippingMailType, "core.shipping_mail_types", "shipping_mail_type_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of ShippingMailType class on the database table "core.shipping_mail_types";
        /// </summary>
        /// <param name="shippingMailTypes">List of "ShippingMailType" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> shippingMailTypes)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. {shippingMailTypes}", this._LoginId, shippingMailTypes);
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
                        foreach (dynamic shippingMailType in shippingMailTypes)
                        {
                            line++;

                            shippingMailType.audit_user_id = this._UserId;
                            shippingMailType.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = shippingMailType.shipping_mail_type_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(shippingMailType.shipping_mail_type_id);
                                db.Update("core.shipping_mail_types", "shipping_mail_type_id", shippingMailType, shippingMailType.shipping_mail_type_id);
                            }
                            else
                            {
                                result.Add(db.Insert("core.shipping_mail_types", "shipping_mail_type_id", shippingMailType));
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
        /// Updates the row of the table "core.shipping_mail_types" with an instance of "ShippingMailType" class against the primary key value.
        /// </summary>
        /// <param name="shippingMailType">The instance of "ShippingMailType" class to update.</param>
        /// <param name="shippingMailTypeId">The value of the column "shipping_mail_type_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic shippingMailType, int shippingMailTypeId)
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
                    Log.Information("Access to edit entity \"ShippingMailType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {ShippingMailType}", shippingMailTypeId, this._LoginId, shippingMailType);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, shippingMailType, shippingMailTypeId, "core.shipping_mail_types", "shipping_mail_type_id");
        }

        /// <summary>
        /// Deletes the row of the table "core.shipping_mail_types" against the primary key value.
        /// </summary>
        /// <param name="shippingMailTypeId">The value of the column "shipping_mail_type_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int shippingMailTypeId)
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
                    Log.Information("Access to delete entity \"ShippingMailType\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", shippingMailTypeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM core.shipping_mail_types WHERE shipping_mail_type_id=@0;";
            Factory.NonQuery(this._Catalog, sql, shippingMailTypeId);
        }

        /// <summary>
        /// Performs a select statement on table "core.shipping_mail_types" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "ShippingMailType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> GetPaginatedResult()
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
                    Log.Information("Access to the first page of the entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_mail_types ORDER BY shipping_mail_type_id LIMIT 10 OFFSET 0;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "core.shipping_mail_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "ShippingMailType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> GetPaginatedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM core.shipping_mail_types ORDER BY shipping_mail_type_id LIMIT 10 OFFSET @0;";

            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql, offset);
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM core.filters WHERE object_name='core.shipping_mail_types' AND lower(filter_name)=lower(@0);";
            return Factory.Get<EntityParser.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "core.shipping_mail_types".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "ShippingMailType" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.shipping_mail_types WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingMailType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.shipping_mail_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "ShippingMailType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.shipping_mail_types WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingMailType(), filters);

            sql.OrderBy("shipping_mail_type_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "core.shipping_mail_types".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "ShippingMailType" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.shipping_mail_types WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingMailType(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.shipping_mail_types" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "ShippingMailType" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingMailType> GetFiltered(long pageNumber, string filterName)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"ShippingMailType\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.shipping_mail_types WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingMailType(), filters);

            sql.OrderBy("shipping_mail_type_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.ShippingMailType>(this._Catalog, sql);
        }


    }
}