namespace MVCTutorial.Models
{
    public class User
    {
        /*
         * Getter and Setter
         * Usually handled by the Model and Controller for Parameter binding
         * -----
         * get - Allows you to get this parameter anywhere
         * set - Allows the auto-binding to happen when the parameter injected matches the requirement
         */
        
        public int Id { get; set; }
        public string username { get; set; }
    }
}