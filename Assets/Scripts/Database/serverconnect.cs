using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class serverconnect : ServerConnect
{
    public void connect()
    {
        string connetionString;
        SqlConnection cnn;
        //keep in mind it is my connection string and it should be changed for other users
        connetionString = "Data Source=Laptop-omsm3ee0;Initial Catalog = Library; Integrated Security = True";
        cnn = new SqlConnection(connetionString);
        cnn.Open();
        MessageBox.Show("Connection Opened");
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
    public void updateScoreLastDay()
    {
        cnn.Open();
        using (DataContext objDataContext = new DataContext())
    {
        var player = (from db in objDataContext.Player
        where db.username = _username
        select db).FirstOrDefault();
        if (player != null)
        {
        player.scoreLastDay = _score;
        objDataContext.SaveChanges();
        }
    }
        cnn.Close();
    }

    public void updateLastDayConnection(string username)
    {
        cnn.Open();
        using (DataContext objDataContext = new DataContext())
    {
        var player = (from db in objDataContext.Player
        where db.username = username
        select db).FirstOrDefault();
        if (player != null)
        {
        player.lastDayConnection = DateTime.Now;
        objDataContext.SaveChanges();
        }
    }
        cnn.Close();
    }

    public int GetPlayerId(string username)
    {
        int playerId = 0;
        cnn.Open();
        using (DataContext objDataContext = new DataContext())
    {
        var player = (from db in objDataContext.Player
        where db.username = username
        select db).FirstOrDefault();
        if (player != null)
        {
        playerId = player.PlayerId;
        }
    }
        cnn.Close();
       return playerId;
    }

    public List<Task> GetTasks(int playerId)
    {
        List<Task> tasks = new List<Task>();
        cnn.Open();
        using (DataContext objDataContext = new DataContext())
    {
        tasks = (from db in objDataContext.Tasks
        where db.PlayerId = playerId
        select db).ToList();
    }
        cnn.Close();
        return tasks;
    }
}