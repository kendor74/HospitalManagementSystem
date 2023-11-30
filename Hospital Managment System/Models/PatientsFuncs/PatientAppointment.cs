namespace Hospital_Managment_System.Models.PatientFuncs
{
    public class PatientAppointment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Catigory { get; set; }
        public DateTime AppointmentTime{ get; set; }
        public DateTime RegisteredTime{ get; set; }
        
    }
}
