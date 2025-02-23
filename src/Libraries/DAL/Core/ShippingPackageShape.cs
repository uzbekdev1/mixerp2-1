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
    /// Provides simplified data access features to perform SCRUD operation on the database table "core.shipping_package_shapes".
    /// </summary>
    public class ShippingPackageShape : DbAccess, IShippingPackageShapeRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "core".
        /// </summary>
        public override string _ObjectNamespace => "core";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "shipping_package_shapes".
        /// </summary>
        public override string _ObjectName => "shipping_package_shapes";

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
        /// Performs SQL count on the table "core.shipping_package_shapes".
        /// </summary>
        /// <returns>Returns the number of rows of the table "core.shipping_package_shapes".</returns>
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
                    Log.Information("Access to count entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM core.shipping_package_shapes;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_package_shapes" to return all instances of the "ShippingPackageShape" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "ShippingPackageShape" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetAll()
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
                    Log.Information("Access to the export entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_package_shapes" to return all instances of the "ShippingPackageShape" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "ShippingPackageShape" class.</returns>
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
                    Log.Information("Access to the export entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_package_shapes" with a where filter on the column "shipping_package_shape_id" to return a single instance of the "ShippingPackageShape" class. 
        /// </summary>
        /// <param name="shippingPackageShapeId">The column "shipping_package_shape_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "ShippingPackageShape" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public MixERP.Net.Entities.Core.ShippingPackageShape Get(int shippingPackageShapeId)
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
                    Log.Information("Access to the get entity \"ShippingPackageShape\" filtered by \"ShippingPackageShapeId\" with value {ShippingPackageShapeId} was denied to the user with Login ID {_LoginId}", shippingPackageShapeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_package_shapes WHERE shipping_package_shape_id=@0;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql, shippingPackageShapeId).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "core.shipping_package_shapes" with a where filter on the column "shipping_package_shape_id" to return a multiple instances of the "ShippingPackageShape" class. 
        /// </summary>
        /// <param name="shippingPackageShapeIds">Array of column "shipping_package_shape_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "ShippingPackageShape" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> Get(int[] shippingPackageShapeIds)
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
                    Log.Information("Access to entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. shippingPackageShapeIds: {shippingPackageShapeIds}.", this._LoginId, shippingPackageShapeIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_package_shapes WHERE shipping_package_shape_id IN (@0);";

            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql, shippingPackageShapeIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for core.shipping_package_shapes.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table core.shipping_package_shapes</returns>
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
                    Log.Information("Access to get custom fields for entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='core.shipping_package_shapes' ORDER BY field_order;";
                return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('core.shipping_package_shapes'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of core.shipping_package_shapes.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table core.shipping_package_shapes</returns>
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
                    Log.Information("Access to get display field for entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT shipping_package_shape_id AS key, shipping_package_shape_code || ' (' || shipping_package_shape_name || ')' as value FROM core.shipping_package_shapes;";
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
        /// Inserts or updates the instance of ShippingPackageShape class on the database table "core.shipping_package_shapes".
        /// </summary>
        /// <param name="shippingPackageShape">The instance of "ShippingPackageShape" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic shippingPackageShape, List<EntityParser.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            shippingPackageShape.audit_user_id = this._UserId;
            shippingPackageShape.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = shippingPackageShape.shipping_package_shape_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                primaryKeyValue = shippingPackageShape.shipping_package_shape_id;
                this.Update(shippingPackageShape, int.Parse(shippingPackageShape.shipping_package_shape_id));
            }
            else
            {
                primaryKeyValue = this.Add(shippingPackageShape);
            }

            string sql = "DELETE FROM core.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM core.custom_field_setup " +
                         "WHERE form_name=core.get_custom_field_form_name('core.shipping_package_shapes')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO core.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT core.get_custom_field_setup_id_by_table_name('core.shipping_package_shapes', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of ShippingPackageShape class on the database table "core.shipping_package_shapes".
        /// </summary>
        /// <param name="shippingPackageShape">The instance of "ShippingPackageShape" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic shippingPackageShape)
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
                    Log.Information("Access to add entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. {ShippingPackageShape}", this._LoginId, shippingPackageShape);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, shippingPackageShape, "core.shipping_package_shapes", "shipping_package_shape_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of ShippingPackageShape class on the database table "core.shipping_package_shapes";
        /// </summary>
        /// <param name="shippingPackageShapes">List of "ShippingPackageShape" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> shippingPackageShapes)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. {shippingPackageShapes}", this._LoginId, shippingPackageShapes);
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
                        foreach (dynamic shippingPackageShape in shippingPackageShapes)
                        {
                            line++;

                            shippingPackageShape.audit_user_id = this._UserId;
                            shippingPackageShape.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = shippingPackageShape.shipping_package_shape_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(shippingPackageShape.shipping_package_shape_id);
                                db.Update("core.shipping_package_shapes", "shipping_package_shape_id", shippingPackageShape, shippingPackageShape.shipping_package_shape_id);
                            }
                            else
                            {
                                result.Add(db.Insert("core.shipping_package_shapes", "shipping_package_shape_id", shippingPackageShape));
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
        /// Updates the row of the table "core.shipping_package_shapes" with an instance of "ShippingPackageShape" class against the primary key value.
        /// </summary>
        /// <param name="shippingPackageShape">The instance of "ShippingPackageShape" class to update.</param>
        /// <param name="shippingPackageShapeId">The value of the column "shipping_package_shape_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic shippingPackageShape, int shippingPackageShapeId)
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
                    Log.Information("Access to edit entity \"ShippingPackageShape\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {ShippingPackageShape}", shippingPackageShapeId, this._LoginId, shippingPackageShape);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, shippingPackageShape, shippingPackageShapeId, "core.shipping_package_shapes", "shipping_package_shape_id");
        }

        /// <summary>
        /// Deletes the row of the table "core.shipping_package_shapes" against the primary key value.
        /// </summary>
        /// <param name="shippingPackageShapeId">The value of the column "shipping_package_shape_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int shippingPackageShapeId)
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
                    Log.Information("Access to delete entity \"ShippingPackageShape\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", shippingPackageShapeId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM core.shipping_package_shapes WHERE shipping_package_shape_id=@0;";
            Factory.NonQuery(this._Catalog, sql, shippingPackageShapeId);
        }

        /// <summary>
        /// Performs a select statement on table "core.shipping_package_shapes" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "ShippingPackageShape" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetPaginatedResult()
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
                    Log.Information("Access to the first page of the entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id LIMIT 10 OFFSET 0;";
            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "core.shipping_package_shapes" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "ShippingPackageShape" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetPaginatedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM core.shipping_package_shapes ORDER BY shipping_package_shape_id LIMIT 10 OFFSET @0;";

            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql, offset);
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM core.filters WHERE object_name='core.shipping_package_shapes' AND lower(filter_name)=lower(@0);";
            return Factory.Get<EntityParser.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "core.shipping_package_shapes".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "ShippingPackageShape" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.shipping_package_shapes WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingPackageShape(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.shipping_package_shapes" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "ShippingPackageShape" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.shipping_package_shapes WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingPackageShape(), filters);

            sql.OrderBy("shipping_package_shape_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "core.shipping_package_shapes".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "ShippingPackageShape" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM core.shipping_package_shapes WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingPackageShape(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "core.shipping_package_shapes" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "ShippingPackageShape" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Core.ShippingPackageShape> GetFiltered(long pageNumber, string filterName)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"ShippingPackageShape\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM core.shipping_package_shapes WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Core.ShippingPackageShape(), filters);

            sql.OrderBy("shipping_package_shape_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Core.ShippingPackageShape>(this._Catalog, sql);
        }


    }
}