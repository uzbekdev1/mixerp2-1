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

namespace MixERP.Net.Schemas.Policy.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "policy.auto_verification_policy".
    /// </summary>
    public class AutoVerificationPolicy : DbAccess, IAutoVerificationPolicyRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "policy".
        /// </summary>
        public override string _ObjectNamespace => "policy";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "auto_verification_policy".
        /// </summary>
        public override string _ObjectName => "auto_verification_policy";

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
        /// Performs SQL count on the table "policy.auto_verification_policy".
        /// </summary>
        /// <returns>Returns the number of rows of the table "policy.auto_verification_policy".</returns>
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
                    Log.Information("Access to count entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM policy.auto_verification_policy;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "policy.auto_verification_policy" to return all instances of the "AutoVerificationPolicy" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "AutoVerificationPolicy" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> GetAll()
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
                    Log.Information("Access to the export entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM policy.auto_verification_policy ORDER BY policy_id;";
            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "policy.auto_verification_policy" to return all instances of the "AutoVerificationPolicy" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "AutoVerificationPolicy" class.</returns>
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
                    Log.Information("Access to the export entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM policy.auto_verification_policy ORDER BY policy_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "policy.auto_verification_policy" with a where filter on the column "policy_id" to return a single instance of the "AutoVerificationPolicy" class. 
        /// </summary>
        /// <param name="policyId">The column "policy_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "AutoVerificationPolicy" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public MixERP.Net.Entities.Policy.AutoVerificationPolicy Get(int policyId)
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
                    Log.Information("Access to the get entity \"AutoVerificationPolicy\" filtered by \"PolicyId\" with value {PolicyId} was denied to the user with Login ID {_LoginId}", policyId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM policy.auto_verification_policy WHERE policy_id=@0;";
            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql, policyId).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "policy.auto_verification_policy" with a where filter on the column "policy_id" to return a multiple instances of the "AutoVerificationPolicy" class. 
        /// </summary>
        /// <param name="policyIds">Array of column "policy_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "AutoVerificationPolicy" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> Get(int[] policyIds)
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
                    Log.Information("Access to entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. policyIds: {policyIds}.", this._LoginId, policyIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM policy.auto_verification_policy WHERE policy_id IN (@0);";

            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql, policyIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for policy.auto_verification_policy.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table policy.auto_verification_policy</returns>
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
                    Log.Information("Access to get custom fields for entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='policy.auto_verification_policy' ORDER BY field_order;";
                return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('policy.auto_verification_policy'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<PetaPoco.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of policy.auto_verification_policy.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table policy.auto_verification_policy</returns>
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
                    Log.Information("Access to get display field for entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT policy_id AS key, policy_id as value FROM policy.auto_verification_policy;";
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
        /// Inserts or updates the instance of AutoVerificationPolicy class on the database table "policy.auto_verification_policy".
        /// </summary>
        /// <param name="autoVerificationPolicy">The instance of "AutoVerificationPolicy" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic autoVerificationPolicy, List<EntityParser.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            autoVerificationPolicy.audit_user_id = this._UserId;
            autoVerificationPolicy.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = autoVerificationPolicy.policy_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                primaryKeyValue = autoVerificationPolicy.policy_id;
                this.Update(autoVerificationPolicy, int.Parse(autoVerificationPolicy.policy_id));
            }
            else
            {
                primaryKeyValue = this.Add(autoVerificationPolicy);
            }

            string sql = "DELETE FROM core.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM core.custom_field_setup " +
                         "WHERE form_name=core.get_custom_field_form_name('policy.auto_verification_policy')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO core.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT core.get_custom_field_setup_id_by_table_name('policy.auto_verification_policy', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of AutoVerificationPolicy class on the database table "policy.auto_verification_policy".
        /// </summary>
        /// <param name="autoVerificationPolicy">The instance of "AutoVerificationPolicy" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic autoVerificationPolicy)
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
                    Log.Information("Access to add entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. {AutoVerificationPolicy}", this._LoginId, autoVerificationPolicy);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, autoVerificationPolicy, "policy.auto_verification_policy", "policy_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of AutoVerificationPolicy class on the database table "policy.auto_verification_policy";
        /// </summary>
        /// <param name="autoVerificationPolicies">List of "AutoVerificationPolicy" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> autoVerificationPolicies)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. {autoVerificationPolicies}", this._LoginId, autoVerificationPolicies);
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
                        foreach (dynamic autoVerificationPolicy in autoVerificationPolicies)
                        {
                            line++;

                            autoVerificationPolicy.audit_user_id = this._UserId;
                            autoVerificationPolicy.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = autoVerificationPolicy.policy_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(autoVerificationPolicy.policy_id);
                                db.Update("policy.auto_verification_policy", "policy_id", autoVerificationPolicy, autoVerificationPolicy.policy_id);
                            }
                            else
                            {
                                result.Add(db.Insert("policy.auto_verification_policy", "policy_id", autoVerificationPolicy));
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
        /// Updates the row of the table "policy.auto_verification_policy" with an instance of "AutoVerificationPolicy" class against the primary key value.
        /// </summary>
        /// <param name="autoVerificationPolicy">The instance of "AutoVerificationPolicy" class to update.</param>
        /// <param name="policyId">The value of the column "policy_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic autoVerificationPolicy, int policyId)
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
                    Log.Information("Access to edit entity \"AutoVerificationPolicy\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {AutoVerificationPolicy}", policyId, this._LoginId, autoVerificationPolicy);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, autoVerificationPolicy, policyId, "policy.auto_verification_policy", "policy_id");
        }

        /// <summary>
        /// Deletes the row of the table "policy.auto_verification_policy" against the primary key value.
        /// </summary>
        /// <param name="policyId">The value of the column "policy_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int policyId)
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
                    Log.Information("Access to delete entity \"AutoVerificationPolicy\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", policyId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM policy.auto_verification_policy WHERE policy_id=@0;";
            Factory.NonQuery(this._Catalog, sql, policyId);
        }

        /// <summary>
        /// Performs a select statement on table "policy.auto_verification_policy" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "AutoVerificationPolicy" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> GetPaginatedResult()
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
                    Log.Information("Access to the first page of the entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM policy.auto_verification_policy ORDER BY policy_id LIMIT 10 OFFSET 0;";
            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "policy.auto_verification_policy" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "AutoVerificationPolicy" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> GetPaginatedResult(long pageNumber)
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
                    Log.Information("Access to Page #{Page} of the entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM policy.auto_verification_policy ORDER BY policy_id LIMIT 10 OFFSET @0;";

            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql, offset);
        }

        public List<EntityParser.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM core.filters WHERE object_name='policy.auto_verification_policy' AND lower(filter_name)=lower(@0);";
            return Factory.Get<EntityParser.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "policy.auto_verification_policy".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "AutoVerificationPolicy" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM policy.auto_verification_policy WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Policy.AutoVerificationPolicy(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "policy.auto_verification_policy" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "AutoVerificationPolicy" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM policy.auto_verification_policy WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Policy.AutoVerificationPolicy(), filters);

            sql.OrderBy("policy_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "policy.auto_verification_policy".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "AutoVerificationPolicy" class using the filter.</returns>
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
                    Log.Information("Access to count entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM policy.auto_verification_policy WHERE 1 = 1");
            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Policy.AutoVerificationPolicy(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "policy.auto_verification_policy" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "AutoVerificationPolicy" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.Policy.AutoVerificationPolicy> GetFiltered(long pageNumber, string filterName)
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
                    Log.Information("Access to Page #{Page} of the filtered entity \"AutoVerificationPolicy\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<EntityParser.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM policy.auto_verification_policy WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.Policy.AutoVerificationPolicy(), filters);

            sql.OrderBy("policy_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<MixERP.Net.Entities.Policy.AutoVerificationPolicy>(this._Catalog, sql);
        }


    }
}