using HospitalManagementSystem.Dao;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.Exception;
using System;

namespace HospitalManagementSystem.Main
{
    class MainModule
    {
        static void Main()
        {
            IHospitalService service = new HospitalServiceImpl();

            while (true)
            {
                Console.WriteLine("\n1. Schedule Appointment\n2. View by Appointment ID\n3. Patient Appointments\n4. Doctor Appointments\n5. Update Appointment\n6. Cancel Appointment\n0. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Appointment ID: ");
                            int aId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Patient ID: ");
                            int pId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Doctor ID: ");
                            int dId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Description: ");
                            string desc = Console.ReadLine();
                            var appt = new Appointment(aId, pId, dId, date, desc);
                            Console.WriteLine(service.ScheduleAppointment(appt) ? "Scheduled" : "Failed");
                            break;

                        case "2":
                            Console.Write("Enter Appointment ID: ");
                            int id = int.Parse(Console.ReadLine());
                            var a = service.GetAppointmentById(id);
                            Console.WriteLine(a != null ? a.ToString() : "Not found");
                            break;

                        case "3":
                            Console.Write("Enter Patient ID: ");
                            int pid = int.Parse(Console.ReadLine());
                            var plist = service.GetAppointmentsForPatient(pid);
                            plist.ForEach(ap => Console.WriteLine(ap));
                            break;

                        case "4":
                            Console.Write("Enter Doctor ID: ");
                            int did = int.Parse(Console.ReadLine());
                            var dlist = service.GetAppointmentsForDoctor(did);
                            dlist.ForEach(ap => Console.WriteLine(ap));
                            break;

                        case "5":
                            Console.Write("Enter Appointment ID to Update: ");
                            int uaid = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Date (yyyy-mm-dd): ");
                            DateTime udate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter New Description: ");
                            string udesc = Console.ReadLine();
                            var uappt = new Appointment { AppointmentId = uaid, AppointmentDate = udate, Description = udesc };
                            Console.WriteLine(service.UpdateAppointment(uappt) ? "Updated" : "Failed");
                            break;

                        case "6":
                            Console.Write("Enter Appointment ID to Cancel: ");
                            int caid = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.CancelAppointment(caid) ? "Cancelled" : "Failed");
                            break;

                        case "0": return;

                        default: Console.WriteLine("Invalid choice"); break;
                    }
                }
                catch (PatientNumberNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (RankException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
