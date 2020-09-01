using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using educationSector.DLTableAdapters;
using System.Data;

namespace educationSector
{
    public class BLL
    {
        //functions
        DataTable3TableAdapter dt3Obj = new DataTable3TableAdapter();
        DataTable3TableAdapter dt4Obj = new DataTable3TableAdapter();

        tblActualDataTableAdapter actualData = new tblActualDataTableAdapter();

        //function to get the student details based on cname
        public DataTable GetStudentDetailsByCName(string CName, int sem)
        {
            return dt3Obj.GetStudentsDetailsbasedonCName(CName, sem);
        }


        //function to get the attributes

        public DataTable GetStudentAttributeeees(string CName)
        {
            return dt3Obj.GetStudentAttributeeeeees(CName);
        }

        public DataTable GetAttributeeeessssss(string CName)
        {
            return dt4Obj.GetStudentAttributeeeeees(CName);
        }

        public DataTable GetTestingDataset(string cName)
        {
            return dt3Obj.GetTestingDataset(cName);
        }
        
        public DataTable GetAllTrainingDataset()
        {
            return dt3Obj.GetAllTrainingDataset();
        }

        public DataTable GetRegnoTestingDataset(string cName, int sem)
        {
            return dt3Obj.GetRegnoTestingDataset(cName, sem);
        }

        public DataTable GetTrainingDatasetwithRegNo(string cName)
        {
            return dt3Obj.GetTrainingDatasetwithRegNo(cName);
        }

        public DataTable GetActualData(string cName)
        {
            return actualData.GetActualDataByCNameandSem(cName);
        }
              

    }
}