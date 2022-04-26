using DataAccessLayer.Interfaces;
using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class AgencyRepository : BaseRepo, IAgencyDal
    {
        public AgencyRepository(IConfiguration config) : base(config)
        {
        }

        public int AddOrUpdate(Agency model)
        {
            var current = Get(model.Id);
            if (current == null)
            {
                return Add(model);
            }
            else
            {
                return Update(current, model);
            }
        }

        public int Update(Agency current, Agency update)
        {
            //AcentaUnvani,AcentaEkBİlgi,AcentaKisi,Tel,Fax,Email,OlusturulmaTarihi
            int result = 0;
            string sql = "Update Acenta Set ";
            bool changed = false;
            if (current.Email != update.Email)
            {
                sql += " Email=\'" + update.Email + "\' ,";
                changed = true;
            }
            if (current.AgencyDescription != update.AgencyDescription)
            {
                sql += " AcentaEkBilgi=\'" + update.AgencyDescription + "\' ,";
                changed = true;
            }
            if (current.AgencyRelevantPerson != update.AgencyRelevantPerson)
            {
                sql += " AcentaKisi=\'" + update.AgencyRelevantPerson + "\' ,";
                changed = true;
            }
            if (current.AgencyTitle != update.AgencyTitle)
            {
                sql += " AcentaUnvani=\'" + update.AgencyTitle + "\' ,";
                changed = true;
            }
            if (current.Fax != update.Fax)
            {
                sql += " Fax=\'" + update.Fax + "\' ,";
                changed = true;
            }
            if (current.Phone != update.Phone)
            {
                sql += " Tel=\'" + update.Phone + "\' ,";
                changed = true;
            }
            if (changed)
            {
                sql = sql.Trim(',');
            }
            else
            {
                return result;
            }
            sql += " Where Id=" + current.Id;
            using (var conn = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public int Add(Agency model)
        {
            //INSERT INTO personel(ID,isim,bolum) VALUES(71,'Serap Demirci','Reklam')
            string sql = "Insert Into Acenta(AcentaUnvani,AcentaEkBilgi,AcentaKisi,Tel,Fax,Email,OlusturulmaTarihi) " +
                                                "Values(@acentaUnvan,@acentaBilgi,@acentaKisi,@tel,@fax,@email,@olusturmaTarihi)";
            int result = 0;
            using (var conn = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acentaUnvan", model.AgencyTitle ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@acentaBilgi", model.AgencyDescription ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@acentaKisi", model.AgencyRelevantPerson ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tel", model.Phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fax", model.Fax ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@email", model.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@olusturmaTarihi", DateTime.Now);
                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public Agency Get(int id)
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "Select * From Acenta Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dataTable = new DataTable();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adab = new SqlDataAdapter(cmd);
                adab.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    var user = new Agency()
                    {
                        Id = id,
                        AgencyDescription = dataTable.Rows[0]["AcentaEkBilgi"].ToString(),
                        AgencyTitle = dataTable.Rows[0]["AcentaUnvani"].ToString(),
                        AgencyRelevantPerson = dataTable.Rows[0]["AcentaKisi"].ToString(),
                        Fax = dataTable.Rows[0]["Fax"].ToString(),
                        Phone= dataTable.Rows[0]["Tel"].ToString(),
                        Email = dataTable.Rows[0]["Email"]?.ToString(),
                    };
                    return user;
                }
            }
            return null;
        }

        public IEnumerable<Agency> GetAll()
        {
            List<Agency> agencies = new List<Agency>();
            using (var conn = GetOpenConnection())
            {
                string sql = "Select * From Acenta";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dataTable = new DataTable();
                SqlDataAdapter adab = new SqlDataAdapter(cmd);
                adab.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow R in dataTable.Rows)
                    {

                        var user = new Agency()
                        {
                            Id = Convert.ToInt32(R["Id"]),
                            AgencyDescription = R["AcentaEkBilgi"].ToString(),
                            AgencyTitle = R["AcentaUnvani"].ToString(),
                            AgencyRelevantPerson = R["AcentaKisi"].ToString(),
                            Fax = R["Fax"].ToString(),
                            Phone = R["Tel"].ToString(),
                            Email = R["Email"]?.ToString(),

                        };
                        agencies.Add(user);
                    }
                }
            }
            return agencies;
        }

    }
}
