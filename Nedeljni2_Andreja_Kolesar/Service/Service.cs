using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni2_Andreja_Kolesar.Service
{
    class Service
    {
        #region Get user,manager, doctor, patient, administrator

        public static tblUser GetUser(string username, string password)
        {
            try
            {
                using (MedicalInstitutionEntities3 context = new MedicalInstitutionEntities3())
                {
                    tblUser result = (from x in context.tblUsers where x.username == username && x.password == password select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        //null or manager
        public static tblClinicManager isManager(tblUser e)
        {
            try
            {
                using (MedicalInstitutionEntities3 context = new MedicalInstitutionEntities3())
                {
                    tblClinicManager result = (from x in context.tblClinicManagers where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        //null or doctor
        public static tblClinicDoctor isDoctor(tblUser e)
        {
            try
            {
                using (MedicalInstitutionEntities3 context = new MedicalInstitutionEntities3())
                {
                    tblClinicDoctor result = (from x in context.tblClinicDoctors where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        //null or return patient
        public static tblClinicPatient isPatient(tblUser e)
        {
            try
            {
                using (MedicalInstitutionEntities3 context = new MedicalInstitutionEntities3())
                {
                    tblClinicPatient result = (from x in context.tblClinicPatients where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        //null or return administrator
        public static tblClinicAdministrator isAdministrator(tblUser e)
        {
            try
            {
                using (MedicalInstitutionEntities3 context = new MedicalInstitutionEntities3())
                {
                    tblClinicAdministrator result = (from x in context.tblClinicAdministrators where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }
        #endregion
    }
}
