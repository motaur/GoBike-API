using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using WebApplication1.Models;
using System.Security.Policy;

namespace Test.Models
{
    public class bikeConnection
    {       
        private string allBikes = "bike_prod";
        private string dbname = "shop";
        private MySqlConnection con = new MySqlConnection("server=localhost;database=shop;uid=root;pwd=root;SslMode=none");
        
        public DataTable getBikes()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand(allBikes, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public DataTable getOrdersByUser(string username)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DataTable dat = new DataTable() { TableName = "orders" };

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("usernameP", username)

                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("getOrdersByUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable getUserInfo(string username)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DataTable dat = new DataTable() { TableName = "users" };

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("usernameP", username)
                    
                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("getUserInfo", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable getCartProds(String user)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DataTable dat = new DataTable() { TableName = "prods_in_carts" }; ;

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("userP", user)             
                    
                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand(/*procedureName*/ "cart_prod", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public DataTable addProdToCart(int productIDP, int quantityP, string userP)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("productIDP", productIDP),
                    new MySqlParameter("quantityP", quantityP),
                    new MySqlParameter("userP", userP)

                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("addProdToCart", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public DataTable deleteProdFromCart(int productIDP, string userP)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("productIDP", productIDP),
                    new MySqlParameter("userP", userP)

                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("deleteProdFromCart", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public DataTable addProduct(string brandP, string nameP, string descriptionP, string imageP, int quantityP, double priceP)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("brandP", brandP),
                    new MySqlParameter("nameP", nameP),
                    new MySqlParameter("descriptionP", descriptionP),
                    new MySqlParameter("imageP", imageP),
                    new MySqlParameter("quantityP", quantityP),
                    new MySqlParameter("priceP", priceP)
                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("addProduct", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable deleteProd(int id)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("idP", id)
                    
                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("removeProd", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        //creates oreder from prods exists in user cart
        public DataTable createOrder(string username, float summ)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("usernameP", username),
                    new MySqlParameter("sumP", summ)

                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("create_order", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable UpdateProfile(UserDetailsBindingModel model, string username)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("usernameP", username),
                    new MySqlParameter("firstnameP", model.firstname),
                    new MySqlParameter("lastnameP", model.lastname),
                    new MySqlParameter("stateP", model.state),
                    new MySqlParameter("streetP", model.street),
                    new MySqlParameter("telephoneP", model.telephone),
                    new MySqlParameter("cityP", model.city),
                    new MySqlParameter("zipP", model.zip)
                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("updateUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable registerUser(string username, string password)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();

                DataTable dat = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("usernameP", username),
                    new MySqlParameter("passwordP", password)

                };

                if (con.State == ConnectionState.Open)
                {
                    con.ChangeDatabase(dbname);
                    MySqlCommand cmd = new MySqlCommand("registerUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dat);
                }
                return dat;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}