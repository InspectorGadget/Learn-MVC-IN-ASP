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
         * -----
         * However, this Model is usually referred to an Object. An Object is a "package" or "stack" of list (imagine)
         * which contains the data that you need. Let alone if it's extracted from a SQL Database (MS SQL, MS Access, SQL Server, etc)
         * A Model doesn't ONLY Store data, but it also notifies any new changes to the Controller or View. Thus, that's the point of "Notifier".
         *
         * --- DIVING INTO MODEL ---
         * public "int" Id
         *
         * The Type Casting of "int" can be replaced with other Type Castings as well.
         * Example:
         * public string {}
         * public bool {}
         * public char {}
         * public dynamic {}
         * public double {}
         * public enum {}
         * public float {}
         */
        
        public int Id { get; set; }
        public string username { get; set; }
    }
}