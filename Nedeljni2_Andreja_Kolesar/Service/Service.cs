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
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
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
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
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
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
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
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
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
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
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

        public static tblClinicPatient PatientById(int id)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicPatient result = (from x in context.tblClinicPatients where x.patientId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }

        }

        public static tblUser UserById(int id)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblUser result = (from x in context.tblUsers where x.userId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }

        }


        public static tblClinicManager ManagerById(int id)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicManager result = (from x in context.tblClinicManagers where x.managerId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }

        }

        public static tblClinicDoctor DoctorById(int id)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicDoctor result = (from x in context.tblClinicDoctors where x.doctorId == id select x).FirstOrDefault();
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

        #region existence
        public static bool AdminExist()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    bool r = (from x in context.tblClinicAdministrators select x).Any();
                    return r;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public static bool InstituteExist()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    bool r = (from x in context.tblInstitutes select x).Any();
                    return r;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        #region validation
        public static bool UsedNumber(string number)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    bool b = (from x in context.tblUsers where x.ICnumber == number select x).Any();
                    return b;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return true;
            }
        }

        public static bool UsedUsername(string name)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    bool b = (from x in context.tblUsers where x.username == name select x).Any();
                    return b;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return true;
            }
        }
        #endregion

        #region ADD USER
        public static tblUser AddUser(tblUser user)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (user.userId == 0)
                    {
                        //add 
                        tblUser newUser = new tblUser();
                        newUser.username = user.username;
                        newUser.password = user.password;
                        newUser.ICnumber = user.ICnumber;
                        newUser.gender = user.gender;
                        newUser.dateOfBirth = user.dateOfBirth;
                        newUser.citizenship = user.citizenship;
                        newUser.fullname = user.fullname;
                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        user.userId = newUser.userId;
                        return user;
                    }
                    else
                    {
                        tblUser userToEdit = (from x in context.tblUsers where x.userId == user.userId select x).FirstOrDefault();
                        userToEdit.username = user.username;
                        userToEdit.password = user.password;
                        userToEdit.gender = user.gender;
                        userToEdit.fullname = user.fullname;
                        userToEdit.citizenship = user.citizenship;
                        userToEdit.dateOfBirth = user.dateOfBirth;
                        userToEdit.ICnumber = user.ICnumber;
                        context.SaveChanges();
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD MANAGER

        public static tblClinicManager AddManager(tblClinicManager manager)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (manager.managerId == 0)
                    {
                        //add 
                        tblClinicManager newManager = new tblClinicManager();
                        newManager.floorNumber = manager.floorNumber;
                        newManager.maxNumberOfDoctors = manager.maxNumberOfDoctors;
                        newManager.minNumberOfRooms = manager.minNumberOfRooms;
                        newManager.numberOfOmissions = manager.numberOfOmissions;
                        newManager.userId = manager.userId;
                        context.tblClinicManagers.Add(newManager);
                        context.SaveChanges();
                        manager.managerId = newManager.managerId;
                        return manager;
                    }
                    else
                    {
                        tblClinicManager managerToEdit = (from x in context.tblClinicManagers where x.managerId == manager.managerId select x).FirstOrDefault();
                        managerToEdit.floorNumber = manager.floorNumber;
                        managerToEdit.maxNumberOfDoctors = manager.maxNumberOfDoctors;
                        managerToEdit.minNumberOfRooms = manager.minNumberOfRooms;
                        managerToEdit.numberOfOmissions = manager.numberOfOmissions;
                        managerToEdit.userId = manager.userId;
                        context.SaveChanges();
                        return manager;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD DOCTOR
        public static tblClinicDoctor AddDoctor(tblClinicDoctor doctor)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (doctor.doctorId == 0)
                    {
                        //add 
                        tblClinicDoctor newDoctor = new tblClinicDoctor();
                        newDoctor.account = doctor.account;
                        newDoctor.admissionOfPatients = doctor.admissionOfPatients;
                        newDoctor.department = doctor.department;
                        newDoctor.managerId = doctor.managerId;
                        newDoctor.shift = doctor.shift;
                        newDoctor.userId = doctor.userId;
                        context.tblClinicDoctors.Add(newDoctor);
                        context.SaveChanges();
                        doctor.doctorId = newDoctor.doctorId;
                        return doctor;
                    }
                    else
                    {
                        tblClinicDoctor doctorToEdit = (from x in context.tblClinicDoctors where x.doctorId == doctor.doctorId select x).FirstOrDefault();
                        doctorToEdit.account = doctor.account;
                        doctorToEdit.admissionOfPatients = doctor.admissionOfPatients;
                        doctorToEdit.department = doctor.department;
                        doctorToEdit.managerId = doctor.managerId;
                        doctorToEdit.userId = doctor.userId;
                        doctorToEdit.shift = doctor.shift;
                        context.SaveChanges();
                        return doctor;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD PATIENT
        public static tblClinicPatient AddPatient(tblClinicPatient patient)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (patient.patientId == 0)
                    {
                        //add 
                        tblClinicPatient newPatient = new tblClinicPatient();
                        newPatient.expiryDate = patient.expiryDate;
                        newPatient.cardNumber = patient.cardNumber;
                        newPatient.userId = patient.userId;
                        context.tblClinicPatients.Add(newPatient);
                        context.SaveChanges();
                        patient.patientId = newPatient.patientId;
                        return patient;
                    }
                    else
                    {
                        tblClinicPatient patientToEdit = (from x in context.tblClinicPatients where x.patientId == patient.patientId select x).FirstOrDefault();
                        patientToEdit.expiryDate = patient.expiryDate;
                        patientToEdit.hasVirus = patient.hasVirus;
                        patientToEdit.userId = patient.userId;
                        patientToEdit.cardNumber = patient.cardNumber;
                        patientToEdit.doctorId = patient.doctorId;
                        context.SaveChanges();
                        return patient;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD ADMINISTRATOR
        public static tblClinicAdministrator AddAdministrator(tblClinicAdministrator admin)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (admin.adminId == 0)
                    {
                        //add 
                        tblClinicAdministrator newAdmin = new tblClinicAdministrator();
                        //newAdmin.instituteId = maintenance.instituteId;
                        newAdmin.userId = admin.userId;
                        context.tblClinicAdministrators.Add(newAdmin);
                        context.SaveChanges();
                        admin.adminId = newAdmin.adminId;
                        return admin;
                    }
                    else
                    {
                        tblClinicAdministrator adminToEdit = (from x in context.tblClinicAdministrators where x.adminId == admin.adminId select x).FirstOrDefault();
                        adminToEdit.userId = admin.userId;
                        adminToEdit.instituteId = admin.instituteId;

                        context.SaveChanges();
                        return admin;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD MAINTENANCE
        public static tblClinicMaintenance AddMaintenance(tblClinicMaintenance m)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (m.maintenanceId == 0)
                    {
                        //add 
                        tblClinicMaintenance newM = new tblClinicMaintenance();
                        newM.name = m.name;
                        newM.permissionToExpand = m.permissionToExpand;
                        newM.accessibilityOfInvalids = m.accessibilityOfInvalids;
                        context.tblClinicMaintenances.Add(newM);
                        context.SaveChanges();
                        m.maintenanceId = newM.maintenanceId;
                        return m;
                    }
                    else
                    {
                        tblClinicMaintenance mToEdit = (from x in context.tblClinicMaintenances where x.maintenanceId== m.maintenanceId select x).FirstOrDefault();
                        mToEdit.name = m.name;
                        mToEdit.accessibilityOfInvalids = m.accessibilityOfInvalids;
                        mToEdit.permissionToExpand = m.permissionToExpand;
                        context.SaveChanges();
                        return m;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD CLINIC
        public static tblInstitute AddInstitute(tblInstitute clinic)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    if (clinic.instituteId == 0)
                    {
                        //add 
                        tblInstitute newInstitute = new tblInstitute();
                        newInstitute.instituteOwner = clinic.instituteOwner;
                        newInstitute.name = clinic.name;
                        newInstitute.numberOfAccessPointsForInvalids = clinic.numberOfAccessPointsForInvalids;
                        newInstitute.numberOfAmbulanceAccessPoints = clinic.numberOfAmbulanceAccessPoints;
                        newInstitute.numberOfFloors = clinic.numberOfFloors;
                        newInstitute.numberOfRooms = clinic.numberOfRooms;
                        newInstitute.terrace = clinic.terrace;
                        newInstitute.yard = clinic.yard;
                        newInstitute.address = clinic.address;
                        newInstitute.constructionDate = clinic.constructionDate;
                        context.tblInstitutes.Add(newInstitute);
                        context.SaveChanges();
                        clinic.instituteId = newInstitute.instituteId;
                        return clinic;
                    }
                    else
                    {
                        tblInstitute instituteToEdit = (from x in context.tblInstitutes where x.instituteId == clinic.instituteId select x).FirstOrDefault();
                        instituteToEdit.address = clinic.address;
                        instituteToEdit.constructionDate = clinic.constructionDate;
                        instituteToEdit.instituteOwner = clinic.instituteOwner;
                        instituteToEdit.name = clinic.name;
                        instituteToEdit.numberOfAccessPointsForInvalids = clinic.numberOfAccessPointsForInvalids;
                        instituteToEdit.numberOfAmbulanceAccessPoints = clinic.numberOfAmbulanceAccessPoints;
                        instituteToEdit.numberOfFloors = clinic.numberOfFloors;
                        instituteToEdit.numberOfRooms = clinic.numberOfRooms;
                        instituteToEdit.terrace = clinic.terrace;
                        instituteToEdit.yard = clinic.yard;

                        context.SaveChanges();
                        return clinic;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region get lists, queue
        public static List<vwClinicDoctor> GetDoctorsList()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    List<vwClinicDoctor> list = new List<vwClinicDoctor>();
                    list = (from x in context.vwClinicDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<vwClinicManager> GetManagersList()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    List<vwClinicManager> list = new List<vwClinicManager>();
                    list = (from x in context.vwClinicManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        public static List<vwClinicPatient> GetPatientsList()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    List<vwClinicPatient> list = new List<vwClinicPatient>();
                    list = (from x in context.vwClinicPatients select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public static List<tblClinicMaintenance> GetMaintenanceList()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    List<tblClinicMaintenance> list = new List<tblClinicMaintenance>();
                    list = (from x in context.tblClinicMaintenances select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public static Queue<tblClinicMaintenance> GetMaintenanceQueue()
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    List<tblClinicMaintenance> list = GetMaintenanceList();
                    if (list.Count != 0)
                    {
                        Queue<tblClinicMaintenance> queue = new Queue<tblClinicMaintenance>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            queue.Enqueue(list[i]);
                        }
                        return queue;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        #endregion        

        #region DELETE 
        public static void DeleteMaintenance(tblClinicMaintenance maintenance)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicMaintenance toDelete = (from u in context.tblClinicMaintenances where u.maintenanceId == maintenance.maintenanceId select u).First();
                    context.tblClinicMaintenances.Remove(toDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public static void DeletePatient(tblClinicPatient patient)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicPatient toDelete = (from u in context.tblClinicPatients where u.patientId == patient.patientId select u).First();
                    context.tblClinicPatients.Remove(toDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }


        public static void DeleteManager(tblClinicManager manager)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicManager toDelete = (from u in context.tblClinicManagers where u.managerId == manager.managerId select u).First();
                    context.tblClinicManagers.Remove(toDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }


        public static void DeleteDoctor(tblClinicDoctor doctor)
        {
            try
            {
                using (MedicalInstitutionEntities4 context = new MedicalInstitutionEntities4())
                {
                    tblClinicDoctor toDelete = (from u in context.tblClinicDoctors where u.doctorId == doctor.doctorId select u).First();
                    context.tblClinicDoctors.Remove(toDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        #endregion
    }
}
