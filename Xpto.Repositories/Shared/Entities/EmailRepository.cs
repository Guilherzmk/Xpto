using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Repositories.Shared.Sql;
using System.Net;

namespace Xpto.Repositories.Shared.Entities
{
    public class EmailRepository : IEmailRepository
    {

        private readonly SqlConnectionProvider _connectionProvider;

        public EmailRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Email Insert(int customerCode, Email email)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_customer_email]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[customer_code],")
            .AppendLine("[type],")
            .AppendLine("[address],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@customer_code,")
            .AppendLine("@type,")
            .AppendLine("@address,")
            .AppendLine("@note")
            .AppendLine(" )");
      
            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetEmailParameters(customerCode, email, cm);

            cm.ExecuteNonQuery();

            return email;
        }

        public void Update(int customerCode, Email email)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer_email]")
                .AppendLine(" SET")
                .AppendLine("[id] = @id,")
                .AppendLine("[code] = @code,")
                .AppendLine("[customer_code] = @customer_code,")
                .AppendLine("[type] = @type,")
                .AppendLine("[address] = @address, ")
                .AppendLine("[note] = @note,");


            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetEmailParameters(customerCode, email, cm);

            cm.ExecuteNonQuery();

            connection.Close();
        }

        public int Delete(int code)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_email]")
            .AppendLine(" WHERE [customer_code] = "+code);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", code));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public int DeleteByCustomer(int customerCode)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_customer_email]")
                .AppendLine(" WHERE [customer_code] = @customer_code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public Email Get(int code)
        {
            var commandText = this.GetSelectQuery()
                   .AppendLine(" WHERE [customer_code] = "+ code);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", code));

            var dataReader = cm.ExecuteReader();

            Email email = null;

            while (dataReader.Read())
            {
                email = LoadDataReader(dataReader);
            }

            connection.Close();

            return email;




        }

        public IList<Email> Find()
        {
            var l = new List<Email>();

            var commandText = this.GetSelectQuery();

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var email = LoadDataReader(dataReader);

                l.Add(email);
            }

            return l;
        }

        public IList<Email> Find(int customerCode)
        {
            var l = new List<Email>();

            var commandText = this.GetSelectEmailQuery(customerCode);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var email = LoadDataReader(dataReader);

                l.Add(email);
            }

            return l;
        }

        private void SetEmailParameters(int customerCode, Email email, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", email.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type", email.Type.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@address", email.Address.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", email.Note.GetDbValue()));
        }

        private StringBuilder GetSelectQuery(int? code = null)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[address],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_email] AS A");

            if (code is not null)
            {
                sb.AppendLine(" WHERE A.customer_code =  " + code);
            }

            return sb;
        }

        private StringBuilder GetSelectEmailQuery(int customerCode)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[address],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_email] AS A")
                .AppendLine(" WHERE A.customer_code = "+customerCode);

            return sb;
        }

        private static Email LoadDataReader(SqlDataReader dataReader)
        {
            var email = new Email();

            email.Id = dataReader.GetGuid("id");
            email.Code = dataReader.GetInt32("code");
            email.CustomerCode = dataReader.GetInt32("customer_code");
            email.Type = dataReader.GetString("type");
            email.Address = dataReader.GetString("address");
            email.Note = dataReader.GetString("note");
            return email;
        }
    }
}
