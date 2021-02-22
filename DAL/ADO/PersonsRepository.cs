using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Clinic.Web.Entities;
using Clinic.Web.DAL.Abstract;

namespace Clinic.Web.DAL.ADO
{
    public class PersonsRepository : IPersonsRepository
    {
        public IEnumerable<PersonsEntity> Read()
        {
            List<PersonsEntity> persons = new List<PersonsEntity>();

            const string _procedure = "READ_Persons";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            PersonsEntity _person = new PersonsEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                Name = _dataReader.GetString("name"),
                                Surname = _dataReader.GetString("surname"),
                                Address = _dataReader.GetString("address"),
                                Phone = _dataReader.GetString("phone"),
                            };
                            persons.Add(_person);
                        }
                        _dataReader.Close();
                        //_transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    //_transaction.Rollback();
                }
            }
            return persons;
        }
        public PersonsEntity ReadOne(int _id)
        {
            PersonsEntity persons = new PersonsEntity();

            const string _procedure = "READ_Persons_one";
            var (_connection, _command, _transaction) = new ConnectionManager().CreateConnection(_procedure);
            _command.Parameters.Add(new SqlParameter("@_id", _id));

            using (_connection)
            {
                try
                {
                    using (SqlDataReader _dataReader = _command.ExecuteReader())
                    {
                        while (_dataReader.Read())
                        {
                            PersonsEntity _person = new PersonsEntity
                            {
                                Id = _dataReader.GetInt32("id"),
                                Name = _dataReader.GetString("name"),
                                Surname = _dataReader.GetString("surname"),
                                Address = _dataReader.GetString("address"),
                                Phone = _dataReader.GetString("phone"),
                            };
                            persons = _person;
                        }
                        _dataReader.Close();
                        //_transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    //_transaction.Rollback();
                }
            }
            return persons;
        }
    }
}
