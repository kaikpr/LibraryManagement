﻿using DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class DBSach
    {
        DAL db = null;
        public DBSach()
        {
            db = new DAL();
        }
        public DataSet LayViewSachChoDocGia()
        {
            return db.ExecuteQueryDataSet("Select * from viewSachChoDocGia", CommandType.Text, null);
        }
        public DataTable LayNXB()
        {
            SqlDataAdapter da = db.ReturnDataAdapter("Select * from NhaXuatBan");
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayKeSach()
        {
            SqlDataAdapter da = db.ReturnDataAdapter("Select * from KeSach");
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LayTheLoai()
        {
            SqlDataAdapter da = db.ReturnDataAdapter("Select * from TheLoai");
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataAdapter TimKiemSachChoDocGia(string tenDauSach, string tenNXB, string tenKeSach, string tenTheLoai)
        {
            return db.ReturnDataAdapterWithArgs("spTimKiemSachChoDocGia", CommandType.StoredProcedure,
                new SqlParameter("@tenDauSach", tenDauSach),
                new SqlParameter("@tenNXB", tenNXB),
                new SqlParameter("@tenKeSach", tenKeSach),
                new SqlParameter("@tenTheLoai", tenTheLoai));
        }
    }
}
