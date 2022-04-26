using EntityLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepo, Interfaces.IUserDal
    {
        public UserRepository(IConfiguration config) : base(config)
        {
        }

        public int AddOrUpdate(User model)
        {
            var current=Get(model.Id);
            if(current==null)
            {
                return Add(model);
            }
            else
            {
                return Update(current,model);
            }
        }
        public int Add(User user)
        {
            //INSERT INTO personel(ID,isim,bolum) VALUES(71,'Serap Demirci','Reklam')
            string sql = "Insert Into Kullanicilar(SAPLojistikId,Email,FirmaUnvan,Parola,BelgeGonderimEmail,Rol,VKN) " +
                                                "Values(@sapId,@email,@firm,@password,@emails,@role,@vkn)";
            int result = 0;
            using (var conn = GetOpenConnection())
            {
                SqlCommand cmd=new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email",user.Email);
                cmd.Parameters.AddWithValue("@firm", user.FirmTitle ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@emails", user.DocumentReceivers ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@sapId", user.SAPLogisticId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@vkn", user.VKN ?? (object)DBNull.Value);
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
        public int Update(User current,User update)
        {
            //(Email,FirmaUnvan,Parola,BelgeGonderimEmail,Rol) " +
            //"Values(@email,@firm,@password,@emails,@role)"
            int result = 0;
            string sql = "Update Kullanicilar Set ";
            bool changed=false;
            if(current.Email != update.Email)
            {
                sql+=" Email=\'"+update.Email+"\' ,";
                changed=true;
            }
            if (current.FirmTitle != update.FirmTitle)
            {
                sql += " FirmaUnvan=\'" + update.FirmTitle + "\' ,";
                changed=true;
            }
            if (current.Password != update.Password)
            {
                sql += " Parola=\'" + update.Password + "\' ,";
                changed=true;
            }
            if (current.DocumentReceivers != update.DocumentReceivers)
            {
                sql += " BelgeGonderimEmail=\'" + update.DocumentReceivers + "\' ,";
                changed=true;
            }
            if (current.Role != update.Role)
            {
                sql += " Rol=\'" + update.Role + "\' ,";
                changed=true;
            }
            if (current.SAPLogisticId != update.SAPLogisticId)
            {
                sql += " SAPLojistikId=\'" + update.SAPLogisticId + "\' ,";
                changed=true;
            }
            if (current.VKN != update.VKN)
            {
                sql += " VKN=\'" + update.VKN + "\' ,";
                changed = true;
            }
            if (changed)
            {
                sql=sql.Trim(',');
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

        public User Get(int id)
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "Select * From Kullanicilar Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dataTable = new DataTable();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adab = new SqlDataAdapter(cmd);
                adab.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    var user = new User()
                    {
                        Email = dataTable.Rows[0]["Email"]?.ToString(),
                        FirmTitle = dataTable.Rows[0]["FirmaUnvan"]?.ToString(),
                        Password = dataTable.Rows[0]["Parola"]?.ToString(),
                        DocumentReceivers = dataTable.Rows[0]["BelgeGonderimEmail"]?.ToString(),
                        Role = dataTable.Rows[0]["Rol"].ToString(),
                        Id = Convert.ToInt32(dataTable.Rows[0]["Id"]),
                        VKN = dataTable.Rows[0]["VKN"].ToString(),
                    };
                    if (dataTable.Rows[0]["SAPLojistikId"] != DBNull.Value)
                    {
                        user.SAPLogisticId = Convert.ToInt32(dataTable.Rows[0]["SAPLojistikId"]);
                    }
                    return user;
                }
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var conn = GetOpenConnection())
            {
                string sql = "Select * From Kullanicilar";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dataTable = new DataTable();
                SqlDataAdapter adab = new SqlDataAdapter(cmd);
                adab.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow R in dataTable.Rows)
                    {

                        var user = new User()
                        {
                            Email = R["Email"]?.ToString(),
                            FirmTitle = R["FirmaUnvan"]?.ToString(),
                            Password = R["Parola"]?.ToString(),
                            DocumentReceivers = R["BelgeGonderimEmail"]?.ToString(),
                            Role = R["Rol"].ToString(),
                            Id = Convert.ToInt32(R["Id"]),
                            VKN= R["VKN"].ToString(),
                        };
                        if (R["SAPLojistikId"] != DBNull.Value)
                        {
                            user.SAPLogisticId = Convert.ToInt32(R["SAPLojistikId"]);
                        }
                        users.Add(user); 
                    }
                }
            }
            return users;
        }

        public User GetUserByUsername(string userMail)
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "Select * From Kullanicilar Where Email=@email";
                SqlCommand cmd=new SqlCommand(sql, conn);
                DataTable dataTable = new DataTable();
                cmd.Parameters.AddWithValue("@email", userMail);
                SqlDataAdapter adab = new SqlDataAdapter(cmd);
                adab.Fill(dataTable);
                if(dataTable.Rows.Count > 0)
                {
                    var user= new User()
                    {
                        Email = dataTable.Rows[0]["Email"]?.ToString(),
                        FirmTitle = dataTable.Rows[0]["FirmaUnvan"]?.ToString(),
                        Password = dataTable.Rows[0]["Parola"]?.ToString(),
                        DocumentReceivers = dataTable.Rows[0]["BelgeGonderimEmail"]?.ToString(),
                        Role = dataTable.Rows[0]["Rol"].ToString(),
                        Id = Convert.ToInt32(dataTable.Rows[0]["Id"]),
                        VKN = dataTable.Rows[0]["VKN"].ToString(),
                    };
                    if(dataTable.Rows[0]["SAPLojistikId"] != DBNull.Value)
                    {
                        user.SAPLogisticId = Convert.ToInt32(dataTable.Rows[0]["SAPLojistikId"]);
                    }
                    return user;
                }
            }
            return null;
        }

        public void Delete(int id)
        {
            using (var conn = GetOpenConnection())
            {
                string sql = "Delete  From Kullanicilar Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ChangePassword(int id, string password)
        {
            bool result = false;
            string sql = "Update Kullanicilar Set Parola=@password Where Id=@id";
            using(var conn = GetOpenConnection())
            {
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;

        }
    }
}
