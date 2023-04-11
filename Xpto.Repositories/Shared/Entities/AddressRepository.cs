using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

        public IList<Address> Insert(Address address)
        {
            var result = new List<Address>();
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
            .AppendLine(" )")
            .AppendLine(" SET @code = SCOPE_IDENTITY(); ");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            var code = cm.Parameters.Add(new SqlParameter("@code", address.Code) { Direction = ParameterDirection.Output });

            this.SetAddressParameters(cm, address);

            cm.ExecuteNonQuery();

            address.Code = (int)code.Value;

            result.Add(address);

            return result;
        }

        public IList<Address> InsertMany(IList<Address> addresses)
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
            .AppendLine(" )")
            .AppendLine(" SET @code = SCOPE_IDENTITY(); ");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            foreach (var address in addresses)
            {
                var cm = connection.CreateCommand();
                cm.CommandText = commandText.ToString();

                var code = cm.Parameters.Add(new SqlParameter("@code", address.Code) { Direction = ParameterDirection.Output });

                this.SetAddressParameters(cm, address);

                cm.ExecuteNonQuery();

                address.Code = (int)code.Value;
            }

            return addresses;
        }

        public void Update(Address address)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer]")
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
                .AppendLine("[note] = @note,");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetAddressParameters(cm, address);

            cm.ExecuteNonQuery();

            connection.Close();
        }

        public int Delete(int code)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_address]")
            .AppendLine(" WHERE [customer_code] = @customer_code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@customer_code", code));

            var result = cm.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public IList<Address> DeleteMany(IList<Address> addresses)
        {
            var commandText = new StringBuilder()
            .AppendLine(" DELETE FROM [tb_customer_address]")
            .AppendLine(" WHERE [customer_code] = @customer_code");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            foreach(var address in addresses)
            {
                var cm = connection.CreateCommand();
                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@customer_code", addresses));

                var result = cm.ExecuteNonQuery();
            }

            connection.Close();

            return addresses;


        }

        public Address Get(int code)
        {
            var commandText = this.GetSelectQuery()
                   .AppendLine(" WHERE [code] = @code");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", code));

            var dataReader = cm.ExecuteReader();

            Address address = null;

            while (dataReader.Read())
            {
                address = LoadDataReader(dataReader);
            }

            connection.Close();

            return address;
        }

        public IList<Address> Find()
        {
            var l = new List<Address>();

            var commandText = this.GetSelectQuery();

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

        private void SetAddressParameters(SqlCommand cm, Address address)
        {
            cm.Parameters.Add(new SqlParameter("@id", address.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@adresscode", address.Code.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@customer_code", address.CustomerCode.GetDbValue()));
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
            var address = new Address();

            address.Id = dataReader.GetGuid("id");
            address.CustomerCode = dataReader.GetInt32("customer_code");
            address.Type = dataReader.GetString("type");
            address.Street = dataReader.GetString("street");
            address.Number = dataReader.GetString("number");
            address.Complement = dataReader.GetString("complement");
            address.District = dataReader.GetString("district");
            address.City = dataReader.GetString("city");
            address.State = dataReader.GetString("state");
            address.ZipCode = dataReader.GetString("zip_code");
            address.Note = dataReader.GetString("note");

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
