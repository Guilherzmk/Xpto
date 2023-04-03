using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Repositories.Shared.Sql;
using Xpto.Core.Shared.Entities.Phone;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;

namespace Xpto.Repositories.Shared.Entities
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public PhoneRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Phone Insert(Phone phone)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_customer_phone]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[customer_code],")
            .AppendLine("[type],")
            .AppendLine("[ddd],")
            .AppendLine("[number],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@customer_code,")
            .AppendLine("@type,")
            .AppendLine("@ddd,")
            .AppendLine("@number,")
            .AppendLine("@note")
            .AppendLine(" )")
            .AppendLine(" SET @code = SCOPE_IDENTITY(); ");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            var code = cm.Parameters.Add(new SqlParameter("@code", phone.Code) { Direction = ParameterDirection.Output });

            this.SetPhoneParameters(cm, phone);

            cm.ExecuteNonQuery();

            phone.Code = (int)code.Value;

            return phone;
        }

        public IList<Phone> InsertMany(IList<Phone> phones)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_customer_phone]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[customer_code],")
            .AppendLine("[type],")
            .AppendLine("[ddd],")
            .AppendLine("[number],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@customer_code,")
            .AppendLine("@type,")
            .AppendLine("@ddd,")
            .AppendLine("@number,")
            .AppendLine("@note")
            .AppendLine(" )")
            .AppendLine(" SET @code = SCOPE_IDENTITY(); ");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            foreach (var phone in phones)
            {
                var cm = connection.CreateCommand();
                cm.CommandText = commandText.ToString();

                var code = cm.Parameters.Add(new SqlParameter("@code", phone.Code) { Direction = ParameterDirection.Output });

                this.SetPhoneParameters(cm, phone);

                cm.ExecuteNonQuery();

                phone.Code = (int)code.Value;

            }

            return phones;
        }
        public void Update(Phone phone)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer]")
                .AppendLine(" SET")
                .AppendLine("[id] = @id,")
                .AppendLine("[code] = @code,")
                .AppendLine("[customer_code] = @customer_code,")
                .AppendLine("[type] = @type,")
                .AppendLine("[ddd] = @ddd, ")
                .AppendLine("[number] = @number,")
                .AppendLine("[note] = @note,");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetPhoneParameters(cm, phone);

            cm.ExecuteNonQuery();

            connection.Close();
        }
        public int Delete(int code)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_phone]")
            .AppendLine(" WHERE [customer_code] = " + code);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", code));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }
        public  IList<Phone> DeleteMany(IList<Phone> phones)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_phone]")
            .AppendLine(" WHERE [customer_code] = @customer_code");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            foreach(var phone in phones)
            {
                var cm = connection.CreateCommand();
                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@customer_code", phones));

                var result = cm.ExecuteNonQuery();
            }

            connection.Close();

            return phones;


        }


        public Phone Get(int code)
        {
            var commandText = this.GetSelectQuery()
                   .AppendLine(" WHERE [customer_code] = " + code);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", code));

            var dataReader = cm.ExecuteReader();

            Phone phone = null;

            while (dataReader.Read())
            {
                phone = LoadDataReader(dataReader);
            }

            connection.Close();

            return phone;
        }
        public IList<Phone> Find()
        {
            var l = new List<Phone>();

            var commandText = this.GetSelectQuery();

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var phone = LoadDataReader(dataReader);

                l.Add(phone);
            }

            return l;
        }
        public IList<Phone> Find(int customerCode)
        {
            var l = new List<Phone>();

            var commandText = this.GetSelectPhoneQuery(customerCode);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var phone = LoadDataReader(dataReader);

                l.Add(phone);
            }

            return l;
        }
        private void SetPhoneParameters(SqlCommand cm, Phone phone)
        {
            cm.Parameters.Add(new SqlParameter("@id", phone.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@customer_code", phone.CustomerCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type", phone.Type.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@ddd", phone.Ddd.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@number", phone.Number.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", phone.Note.GetDbValue()));

        }
        public StringBuilder GetSelectQuery(int? code = null)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[ddd],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_phone] AS A");

            if (code is not null)
            {
                sb.AppendLine(" WHERE A.customer_code =  " + code);
            }

            return sb;
        }
        private static Phone LoadDataReader(SqlDataReader dataReader)
        {
            var phone = new Phone();

            phone.Id = dataReader.GetGuid("id");
            phone.CustomerCode = dataReader.GetInt32("customer_code");
            phone.Type = dataReader.GetString("type");
            phone.Type = dataReader.GetString("ddd");
            phone.Ddd = dataReader.GetInt32("number");
            phone.Number = dataReader.GetInt64("note");
   

            return phone;

        }
        public StringBuilder GetSelectPhoneQuery(int customerCode)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[ddd],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_phone] AS A")
                .AppendLine(" WHERE A.customer_code = " + customerCode);

            return sb;
        }
    }
}
