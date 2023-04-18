using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xpto.Core.Customers;
using Xpto.Core.Shared.Entities.Address;
using Xpto.Core.Shared.Entities.Email;
using Xpto.Repositories.Shared.Sql;

namespace Xpto.Repositories.Shared.Entities
{
    public class AddressRepository : IAddressRepository
    {

        private readonly SqlConnectionProvider _connectionProvider;

        public AddressRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Address Insert(int customerCode, Address address)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_customer_address]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[customer_code],")
            .AppendLine("[type],")
            .AppendLine("[street],")
            .AppendLine("[number],")
            .AppendLine("[complement],")
            .AppendLine("[district],")
            .AppendLine("[city],")
            .AppendLine("[state],")
            .AppendLine("[zip_code],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@customer_code,")
            .AppendLine("@type,")
            .AppendLine("@street,")
            .AppendLine("@number,")
            .AppendLine("@complement,")
            .AppendLine("@district,")
            .AppendLine("@city,")
            .AppendLine("@state,")
            .AppendLine("@zip_code,")
            .AppendLine("@note")
            .AppendLine(" )");
          
            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetAddressParameters(customerCode, address, cm);

            cm.ExecuteNonQuery();

            return address;
        }

        
        public void Update(int customerCode, Address address)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer_address]")
                .AppendLine(" SET")
                .AppendLine("[id] = @id,")
                .AppendLine("[customer_code] = @customer_code,")
                .AppendLine("[street] = @street,")
                .AppendLine("[number] = @number,")
                .AppendLine("[complement] = @complement, ")
                .AppendLine("[district] = @district,")
                .AppendLine("[city] = @city,")
                .AppendLine("[state] = @state,")
                .AppendLine("[zip_code] = @zip_code,")
                .AppendLine("[note] = @note")
                .AppendLine("WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetAddressParameters(customerCode, address, cm);

            cm.ExecuteNonQuery();

            connection.Close();
        }
        public int Delete(Guid id)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_address]")
            .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

       
        public int DeleteByCustomer(int customerCode)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_customer_address]")
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

        public Address Get(Guid id)
        {
            var commandText = this.GetSelectQuery()
                   .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var dataReader = cm.ExecuteReader();

            Address address = null;

            while (dataReader.Read())
            {
                address = LoadDataReader(dataReader);
            }

            connection.Close();

            return address;
        }

        public IList<Address> Find(int customerCode)
        {
            var l = new List<Address>();

            var commandText = this.GetSelectAddressQuery(customerCode);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var address = LoadDataReader(dataReader);

                l.Add(address);
            }

            return l;
        }

        public StringBuilder GetSelectQuery(int? code = null)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type]")
                .AppendLine(" A.[street],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[complement],")
                .AppendLine(" A.[district],")
                .AppendLine(" A.[city],")
                .AppendLine(" A.[state],")
                .AppendLine(" A.[zip_code],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_address] AS A");

            if (code is not null)
            {
                sb.AppendLine(" WHERE A.customer_code =  " + code);
            }

            return sb;
        }

        public StringBuilder GetSelectAddressQuery(int customerCode)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[customer_code],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[street],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[complement],")
                .AppendLine(" A.[district],")
                .AppendLine(" A.[city],")
                .AppendLine(" A.[state],")
                .AppendLine(" A.[zip_code],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_customer_address] AS A")
                .AppendLine(" WHERE A.customer_code = " + customerCode);

            return sb;
        }

        private void SetAddressParameters(int customerCode, Address address, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", address.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@customer_code", customerCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type", address.Type.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@street", address.Street.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@number", address.Number.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@complement", address.Complement.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@district", address.District.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@city", address.City.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@state", address.State.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@zip_code", address.ZipCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", address.Note.GetDbValue()));
        }

        public static Address LoadDataReader(SqlDataReader dataReader)
        {
            var address = new Address
            {
                Id = dataReader.GetGuid("id"),
                Type = dataReader.GetString("type"),
                Street = dataReader.GetString("street"),
                Number = dataReader.GetString("number"),
                Complement = dataReader.GetString("complement"),
                District = dataReader.GetString("district"),
                City = dataReader.GetString("city"),
                State = dataReader.GetString("state"),
                ZipCode = dataReader.GetString("zip_code"),
                Note = dataReader.GetString("note")
            };
            return address;
        }

        public DataTable LoadDataTable()
        {
            //var address = _addressRepository.Find();

            var commandTextAddress = new StringBuilder()
                .AppendLine("SELECT")
                .AppendLine("A.[id]")
                .AppendLine("A.[code]")
                .AppendLine("A.[customer_code]")
                .AppendLine("A.[type]")
                .AppendLine("A.[street]")
                .AppendLine("A.[number]")
                .AppendLine("A.[complement]")
                .AppendLine("A.[district]")
                .AppendLine("A.[city]")
                .AppendLine("A.[state]")
                .AppendLine("A.[zip_code]")
                .AppendLine("A.[note]")
                .AppendLine(" FROM [tb_customer_address] AS A");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandTextAddress.ToString();

            var da = new SqlDataAdapter(cm);

            var dataTable = new DataTable();
            da.Fill(dataTable);

            connection.Close();
            da.Dispose();

            return dataTable;
        }
    }
}
