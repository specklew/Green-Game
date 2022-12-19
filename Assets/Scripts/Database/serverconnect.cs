using Linq;

public class serverconnect : ServerConnect
{
   public void connect()
   {
       string connetionString;
       SqlConnection cnn;
       connetionString = @"Data Source=DESKTOP-I9PB7KF;Initial Catalog=greengame;User ID=****;Password=********";
       cnn = new SqlConnection(connetionString);
       cnn.Open();
       MessageBox.Show("Connection Open  !");
       cnn.Close();
   }

   public void getFirstID()
   {
       var lastPlayerID =
           (from playerID in objDataContext.Player
            select playerID).first();
   }

   public void CreateAccountDB()
   {
       cnn.Open();
       using (DataContext objDataContext = new DataContext())
       {
           var existinguser =
           (from db in objDataContext.Player
            where db.username = _login
            select db);
           if (existinguser != null)
           {
               Player objPlayer = new Player();
               existinguser.PlayerID = getFirstID + 1;
               existinguser.username = _login;
               existinguser.password = _password;
               existinguser.lastDayConnection = DateTime.Now;
               existinguser.scoreLastDay = 0;
           }
           else
           {
               // Pop up this user already exists.
           }
       }
       cnn.Close();
   }

   public void LoginDB()
   {
       cnn.Open();
       using (DataContext objDataContext = new DataContext())
       {
           var existingaccount =
           (from db in objDataContext.Player
            where db.username = _login
&& db.password = _password
            select db);
           if (existingaccount != null)
           {
               //Pop up login completed.
           }
           else
           {
               //Pop up login failed.
           }

       }
       cnn.Close();
   }
}